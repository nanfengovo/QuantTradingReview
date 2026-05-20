using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuantTrading.Permissions;
using System.Linq.Dynamic.Core;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace QuantTrading.Tags;

[Authorize(QuantTradingPermissions.Tags.Default)]
[Area("app")]
[RemoteService]
[Route("api/app/tags")]
public class TagAppService : QuantTradingAppService, ITagAppService
{
    private readonly IRepository<Tag, Guid> _tagRepository;
    private readonly IRepository<TradeTag, Guid> _tradeTagRepository;

    public TagAppService(
        IRepository<Tag, Guid> tagRepository,
        IRepository<TradeTag, Guid> tradeTagRepository)
    {
        _tagRepository = tagRepository;
        _tradeTagRepository = tradeTagRepository;
    }

    [HttpGet]
    public async Task<PagedResultDto<TagDto>> GetListAsync(TagListRequestDto input)
    {
        var query = await _tagRepository.GetQueryableAsync();

        if (input.Category.HasValue)
        {
            query = query.Where(x => x.Category == input.Category.Value);
        }

        if (!input.Keyword.IsNullOrWhiteSpace())
        {
            query = query.Where(x => x.Name.Contains(input.Keyword!) || (x.Description ?? string.Empty).Contains(input.Keyword!));
        }

        query = query.OrderBy(input.Sorting.IsNullOrWhiteSpace() ? nameof(Tag.Name) : input.Sorting);
        var totalCount = await AsyncExecuter.CountAsync(query);
        var entities = await AsyncExecuter.ToListAsync(query.Skip(input.SkipCount).Take(input.MaxResultCount));

        var items = new System.Collections.Generic.List<TagDto>();
        foreach (var entity in entities)
        {
            var usageCount = await CountUsageAsync(entity.Id);
            items.Add(Map(entity, usageCount));
        }

        return new PagedResultDto<TagDto>(totalCount, items);
    }

    [Authorize(QuantTradingPermissions.Tags.Create)]
    [HttpPost]
    public async Task<TagDto> CreateAsync(CreateTagDto input)
    {
        var entity = new Tag
        {
            Id = GuidGenerator.Create(),
            TenantId = CurrentTenant.Id,
            Name = input.Name,
            Color = input.Color,
            Category = input.Category,
            Description = input.Description
        };

        await _tagRepository.InsertAsync(entity, autoSave: true);
        return Map(entity, 0);
    }

    [Authorize(QuantTradingPermissions.Tags.Delete)]
    [HttpDelete("{id:guid}")]
    public async Task DeleteAsync(Guid id)
    {
        await _tagRepository.DeleteAsync(id);
    }

    [Authorize(QuantTradingPermissions.Tags.Bind)]
    [HttpPost("/api/app/trade-records/{tradeRecordId:guid}/tags")]
    public async Task<TradeTagBindingDto> BindTradeTagsAsync(Guid tradeRecordId, BindTradeTagsDto input)
    {
        var query = await _tradeTagRepository.GetQueryableAsync();
        var existing = await AsyncExecuter.ToListAsync(query.Where(x => x.TradeRecordId == tradeRecordId));
        foreach (var relation in existing)
        {
            await _tradeTagRepository.DeleteAsync(relation);
        }

        foreach (var tagId in input.TagIds.Distinct())
        {
            await _tradeTagRepository.InsertAsync(new TradeTag
            {
                Id = GuidGenerator.Create(),
                TenantId = CurrentTenant.Id,
                TradeRecordId = tradeRecordId,
                TagId = tagId
            });
        }

        await CurrentUnitOfWork.SaveChangesAsync();

        var tagEntities = await AsyncExecuter.ToListAsync((await _tagRepository.GetQueryableAsync()).Where(x => input.TagIds.Contains(x.Id)));
        return new TradeTagBindingDto
        {
            TradeRecordId = tradeRecordId,
            Tags = tagEntities.Select(x => Map(x, 0)).ToArray()
        };
    }

    private async Task<int> CountUsageAsync(Guid tagId)
    {
        var tradeTagQuery = await _tradeTagRepository.GetQueryableAsync();
        return await AsyncExecuter.CountAsync(tradeTagQuery.Where(x => x.TagId == tagId));
    }

    internal static TagDto Map(Tag entity, int usageCount)
    {
        return new TagDto
        {
            Id = entity.Id,
            CreationTime = entity.CreationTime,
            CreatorId = entity.CreatorId,
            LastModificationTime = entity.LastModificationTime,
            LastModifierId = entity.LastModifierId,
            Name = entity.Name,
            Color = entity.Color,
            Category = entity.Category,
            Description = entity.Description,
            UsageCount = usageCount
        };
    }
}
