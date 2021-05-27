const PROXY_CONFIG = [
  {
    context: ['/api'],
    target: 'http://localhost:44342',
    // 'secure': false,
    // pathRewrite: {
    //   '^/microservices': ''
    // },
    logLevel: 'debug',
    // changeOrigin: true
  }
]

module.exports = PROXY_CONFIG;