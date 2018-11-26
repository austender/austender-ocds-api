# AUSTENDER OCDS API
The Open Contracting Data Standard (OCDS) enables disclosure of data and documents at all stages of the contracting process by defining a common data model. It was created to support organizations to increase contracting transparency, and allow deeper analysis of contracting data by a wide range of users.<sup>[1](#references)</sup>

This developer portal will provide users of Austender data with documentation, code examples, bug notifications and feature requests. The [Wiki](#austender-ocds-api) provides technical details about search parameters and expected results.

## About
[AusTender](https://tenders.gov.au)<sup>[2](#references)</sup> is an online tendering system used by the Federal Government agencies to make available information about tendering opportunities. The API makes all AusTender data (ATMs, CNs, SONs, and PPs) available on demand in a standard machine-readable format. The service is provided with compliance with the Open Contracting Data standard and built using the latest [AWS](https://aws.amazon.com) Serverless Technologies and [Serverless Framework](https://serverless.com).

### Notes
The Procurement Office of the Department of Finance spearheaded the implementation of OCDS standards for [AusTender](https://tenders.gov.au), starting with Contract Notices. Other AusTender data will follow soon on the next versions.

## AusTender OCDS API Call
As of this writing, there are few API calls available:

- [Search by Contract CN ID](https://ocdsapi.tenders.gov.au/ocds/findById/CN00000000)
- [Search by Contract Published Date](https://ocdsapi.tenders.gov.au/ocds/findByDates/contractPublished/yyyy-mm-ddThh:mi:ssZ/yyyy-mm-ddThh:mi:ssZ)
- [Search by Contract Start Date](https://ocdsapi.tenders.gov.au/ocds/findByDates/contractStart/yyyy-mm-ddThh:mi:ssZ/yyyy-mm-ddThh:mi:ssZ)
- [Search by Contract End Date](https://ocdsapi.tenders.gov.au/ocds/findByDates/contractEnd/yyyy-mm-ddThh:mi:ssZ/yyyy-mm-ddThh:mi:ssZ)
- [Search by Contract Latest Modified Date](https://ocdsapi.tenders.gov.au/ocds/findByDates/contractLastModified/yyyy-mm-ddThh:mi:ssZ/yyyy-mm-ddThh:mi:ssZ)

A detailed documentation of the API is available at [AusTender OCDS Swagger Hub](https://app.swaggerhub.com/apis-docs/austender/ocds-api/)

### Notes
- Dates on the Resftul API Path Parameters should be in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) Time Interval Formats.

### Authors
- Rodel Talampas
- Ronghuan Zhao
- Pankaj Pandav
- Xiutao Liu
- Yang Li

### References
1. http://standard.open-contracting.org/
2. https://tenders.gov.au
