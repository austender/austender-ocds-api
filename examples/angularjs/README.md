# AngularJS API call
This is a UI page for querying the CNs based on the CN ID or Publish Date by calling the given API which can be configured.

## Requirements
 - AngularJS v1.7.5
 - jQuery v1.12.4
 - jQuery UI - v1.12.1
 - Bootstrap v4.0.0
 - OCDS API Call URL (https://app.swaggerhub.com/apis-docs/austender/ocds-api/1.0)

## Use the UI
Run the Index.html and the page has two links below:
- Search by CN ID. This link goes to a form where you can search CNs by CN ID.
- Search by Publish Date. This links goes to a form where you you can search by Publish Date(Both "From" and "To" must be provided.)

The above search execute queries and list the results on the same page below the search form. If the CN has amendments, then it lists every amendment with a link which goes to the amendment details.

## Download code and setup
- The code can be downloaded directly or cloned by git tools (SourceTree, etc).
- Open the Index.html with browsers.
- The API URL can be configured in the config.js file. (findByIdUrl or findByPublishDateUrl)

## Test the UI
When searching in the form,
1. The CN ID format should include "CN" prefix such as CN2086021;
2. The Publish Date should be a "yyyy-MM-dd" format;
3. When the format is incorret, there're no results returned.

## Note

- This sample code does not go through results that has pagination.
