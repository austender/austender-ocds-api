# AUSTENDER OCDS API
The Open Contracting Data Standard (OCDS) was created to increase contracting transparency, and allow deeper analysis of contracting data by a wide range of users.<sup>[1](#references)</sup>

This portal provides consumers of AusTender data with documentation, code examples, bug notifications and feature requests. 

## About
[AusTender](https://tenders.gov.au)<sup>[2](#references)</sup> is the Australian Government procurement information system. The API provides AusTender CN data on demand in a standard machine-readable format.

### Notes
The data and schema are compliant with the Open Contracting Data Standard and developed using the latest [AWS](https://aws.amazon.com) Serverless Technologies and [Serverless Framework](https://serverless.com).

## AusTender OCDS API Call
There are various API calls available:

- [Search by Contract Notice ID](https://api.tenders.gov.au/ocds/findById/CN00000000)
- [Search by Contract Notice Published Date](https://api.tenders.gov.au/ocds/findByDates/contractPublished/yyyy-mm-ddThh:mi:ssZ/yyyy-mm-ddThh:mi:ssZ)
- [Search by Contract Notice Start Date](https://api.tenders.gov.au/ocds/findByDates/contractStart/yyyy-mm-ddThh:mi:ssZ/yyyy-mm-ddThh:mi:ssZ)
- [Search by Contract Notice End Date](https://api.tenders.gov.au/ocds/findByDates/contractEnd/yyyy-mm-ddThh:mi:ssZ/yyyy-mm-ddThh:mi:ssZ)
- [Search by Contract Notice Latest Modified Date](https://api.tenders.gov.au/ocds/findByDates/contractLastModified/yyyy-mm-ddThh:mi:ssZ/yyyy-mm-ddThh:mi:ssZ)

Detailed documentation of the API is available at [AusTender OCDS Swagger Hub](https://app.swaggerhub.com/apis/austender/ocds-api/1.1#/)

### Notes
- Dates on the RESTful API Path Parameters should be in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) Time Interval Formats.

### References
1. http://standard.open-contracting.org/
2. https://tenders.gov.au
