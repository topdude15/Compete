# Changelog

## [2.0.0-preview.18] - 2019-05-20
- Fixed a CI issue causing native artifacts not to be included in the package

## [2.0.0-preview.17] - 2019-05-17
- Hide UI toggles for clipping plane enforcement from MagicLeapCamera (toggles were previously disabled)
- Do not fail when requesting confidence for a zero-vertex mesh
- Update tooltips for MagicLeapCamera

## [2.0.0-preview.16] - 2019-03-27
- Properly report when Xcode is missing on OSX, which is required as part of the remote library import process.
- Fix duplicate yamato jobs.
- Expose the RenderingSettings protected_surface parameter through the MagicLeapCamera component.
- Add a CODEOWNERS file to the repo
- Fix a false positive library load error on device; the libraries were already loaded by then anyways.

## [2.0.0-preview.15] - 2019-03-06
- Fix an issue where MLSpatialMapper fails to initialize if enabled after entering playmode using ML Remote
- Fix an number of issues blocking package publication

## [2.0.0-preview.14] - 2019-03-05
- Fix a number of issues causing instabilty when using ML Remote