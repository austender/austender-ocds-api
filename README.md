# AUSTENDER OCDS API
The Open Contracting Data Standard (OCDS) was created to increase contracting transparency, and allow deeper analysis of contracting data by a wide range of users.<sup>[1](#references)</sup>

This developer portal provides consumers of AusTender data with documentation, code examples, bug notifications and feature requests. The [Wiki](#austender-ocds-api) provides technical details about search parameters and expected results.

## About
[AusTender](https://tenders.gov.au)<sup>[2](#references)</sup> s the Australian Governments procurement information system. The API provides AusTender CN data on demand in a standard machine-readable format.

### Notes
The data and schema are compliant with the Open Contracting Data standard and developed using the latest [AWS](https://aws.amazon.com) Serverless Technologies and [Serverless Framework](https://serverless.com).

## AusTender OCDS API Call
There are various API calls available:

- [Search by Contract Notice ID](https://api.tenders.gov.au/ocds/findById/CN00000000)
- [Search by Contract Notice Published Date](https://api.tenders.gov.au/ocds/findByDates/contractPublished/yyyy-mm-ddThh:mi:ssZ/yyyy-mm-ddThh:mi:ssZ)
- [Search by Contract Notice Start Date](https://api.tenders.gov.au/ocds/findByDates/contractStart/yyyy-mm-ddThh:mi:ssZ/yyyy-mm-ddThh:mi:ssZ)
- [Search by Contract Notice End Date](https://api.tenders.gov.au/ocds/findByDates/contractEnd/yyyy-mm-ddThh:mi:ssZ/yyyy-mm-ddThh:mi:ssZ)
- [Search by Contract Notice Latest Modified Date](https://api.tenders.gov.au/ocds/findByDates/contractLastModified/yyyy-mm-ddThh:mi:ssZ/yyyy-mm-ddThh:mi:ssZ)

A detailed documentation of the API is available at [AusTender OCDS Swagger Hub](https://app.swaggerhub.com/apis-docs/austender/ocds-api/)

### Notes
- Dates on the RESTful API Path Parameters should be in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) Time Interval Formats.

### Authors
- Rodel Talampas
- Ronghuan Zhao
- Pankaj Pandav
- Xiutao Liu
- Yang Li

### References
1. http://standard.open-contracting.org/
2. https://tenders.gov.au
