// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  appVersion: '1.0.0',
  tokenKey: 'F78CN6nmLQ',
  apiUrl: 'https://localhost:44310/api',
  dropboxHost: 'https://www.dropbox.com/s/',
  uploadURL: {
    upload: 'https://localhost:44310/api/file/upload',
    storage: 'https://localhost:44310/api/file/storage',
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
