# Java API call
This is a UI page for querying the CNs based on the CN ID or Publish Date by calling the given API which can be configured.

## Framework
 - JavaServer Faces (JSF) (https://www.tutorialspoint.com/jsf/)
 - jQuery UI (https://jqueryui.com/)

## Use the UI
Run the application and it goes to Index.html which has two links below:
- Search by CN ID. This link goes to a form where you can search CNs by CN ID.
- Search by Publish Date. This links goes to a form where you you can search by Publish Date(Both "From" and "To" must be provided.)

The above search execute queries and list the results on the same page below the search form. If the CN has amendments, then it lists every amendment with a link which goes to the amendment details.

## Download code and setup
- The code can be downloaded directly or cloned by git tools (SourceTree, etc).
- In the Eclipse, open the project, build and run the application with Tomcat. 
- The API URL can be configured in the src/config.properties file. (FindByIdUrl or FindByPublishDateUrl)

## Test the UI
When searching in the form, 
1. The CN ID format should include "CN" prefix such as CN2086021;
2. The Publish Date should be a "yyyy-MM-dd" format;
3. When the format is incorret, there're no results returned.
