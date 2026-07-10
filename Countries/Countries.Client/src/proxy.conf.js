const { env } = require('process');

const target = 'http://localhost:5000';

const PROXY_CONFIG = [
  {
    context: ['/api'],
    target: target,
    secure: false,
    pathRewrite: { '^/api': '' },
  },
];

module.exports = PROXY_CONFIG;
