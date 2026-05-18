import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import { VitePWA } from 'vite-plugin-pwa';
// 1. 引入 tailwindcss 插件
import tailwindcss from '@tailwindcss/vite';

export default defineConfig({
  plugins: [
    react(),
    tailwindcss(),//启用插件
    VitePWA({
      // 内部工具建议设为自动更新，只要刷新页面就拉取新版本
      registerType: 'autoUpdate',
      
      // 包含哪些静态资源进行离线缓存
      includeAssets: ['favicon.ico', 'apple-touch-icon.png', 'safari-pinned-tab.svg'],
      
      // PWA 的清单文件配置 (这就是能被添加到手机桌面的关键)
      manifest: {
        name: 'Alpha Capital 交易复盘系统',
        short_name: '交易复盘',
        description: '内部量化交易与手动复盘看板',
        theme_color: '#ffffff', // 你的 UI 主题色
        background_color: '#f3f4f6',
        display: 'standalone', // 沉浸式全屏体验，隐藏浏览器地址栏
        icons: [
          {
            src: 'pwa-192x192.png', // 你需要准备一张 192x192 的 Logo 放在 public 目录下
            sizes: '192x192',
            type: 'image/png'
          },
          {
            src: 'pwa-512x512.png', // 你需要准备一张 512x512 的 Logo 放在 public 目录下
            sizes: '512x512',
            type: 'image/png'
          }
        ]
      }
    })
  ],
  // 解决开发环境跨域调用后端 API 的问题
  server: {
    proxy: {
      '/api': {
        target: 'http://localhost:5000', // 你的 ABP 后端地址
        changeOrigin: true,
        secure: false,
      }
    }
  }
});