// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  local: true,
  dev: false,
  test: false,
  staging: false,
  production: false,
  apiBase: 'http://localhost:1234/api',
  sqPaymentLocationId: 'CBASENNFtBfyHxNWNBGrFdjLx-ggAQ',
  sqPaymentAppId: 'sandbox-sq0idp-REYN1AJNPBWiTFA1Po9Faw',
};
