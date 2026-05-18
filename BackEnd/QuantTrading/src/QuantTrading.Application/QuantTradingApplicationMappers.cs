using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using QuantTrading.Books;

namespace QuantTrading;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class QuantTradingBookToBookDtoMapper : MapperBase<Book, BookDto>
{
    public override partial BookDto Map(Book source);

    public override partial void Map(Book source, BookDto destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class QuantTradingCreateUpdateBookDtoToBookMapper : MapperBase<CreateUpdateBookDto, Book>
{
    public override partial Book Map(CreateUpdateBookDto source);

    public override partial void Map(CreateUpdateBookDto source, Book destination);
}
