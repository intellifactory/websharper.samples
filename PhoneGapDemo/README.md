# PhoneGapDemo

This sample demonstrates how to use [WebSharper][ws] to create a
[PhoneGap][pg] / Apache Cordova application using
`WebSharper.PhoneGap` bindings.

PhoneGap applications are build with JavaScript/HTML5 and are compiled
to native applications on a variety on platforms, including iOS,
Android, Windows Phone and Windows 8.

## Building

Besides normal [WebSharper][ws] requirements you will need [npm][npm]
(Windows users can obtain this tool by installing
[nodejs](http://nodejs.org/)) and the [cordova][cordova-tool] tool,
which can be obtained like this:

    npm install -g cordova

First, perform a regular WebSharper build, which populates assets
under `app/www`, but does not perform the actual build.  The `app`
folder is the root of your Cordova application, managed by the
`cordova` tool.

### Enabling plugins

Enable all of the following plugins:

    cd app
    cordova plugin add org.apache.cordova.camera
    cordova plugin add org.apache.cordova.contacts
    cordova plugin add org.apache.cordova.device-orientation
    cordova plugin add org.apache.cordova.device-motion
    cordova plugin add org.apache.cordova.geolocation

### Building and testing native mobile apps

For example, assuming you have Android SDK and paths configured
correctly, you can:

    cordova platforms add android
    cordova android build
    cordova android run
    
More information can be found in [PhoneGap][pg] documentation and
manuals specific to your target platform and SDK.

## License

All files in this demo are released under Apache 2.0 License.

[cordova-tool]: http://docs.phonegap.com/en/3.4.0/guide_cli_index.md.html#The%20Command-Line%20Interface
[npm]: https://www.npmjs.org/
[pg]: http://phonegap.com/
[ws]: http://websharper.com
