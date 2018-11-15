# Python API call
This is a UI page for querying the CNs based on the CN ID or Publish Date by calling the given API which can be configured.

## Web Framework
This project use a free and open source Python Web Framework,Django.
### Versions:
 - Ptyhon 3.7.1
 - Django 2.2
	
## Setup
You can download the Project directly from Git Hub
Using a IDE,to open the project,such as PyChamrm.Several files need to be mentioned
 - templates directory contain the template files
 - ApiWeb/config.oy,config the API URL
 - ApiWeb/RequestHelper.py,a service that call the API
	
## Launch Django server
	Open the terminal window and enter the command 'python manage.py runserver 0.0.0.0:8000';
	Then open the 'http://127.0.0.1:8000' in the browser.

## Test the UI
The home page contains links to the query page.
 - The CN ID format should include "CN" prefix such as CN2086021;
 - The Publish Date should be a "yyyy-MM-dd" format;
