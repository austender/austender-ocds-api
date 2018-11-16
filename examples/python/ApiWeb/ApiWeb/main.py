from ApiWeb.RequestHelper import RequestHelper

url = 'https://dev-tenders-ocds-api.tenders.gov.au/dev/ocds/findById/CN2990488'
str_json = RequestHelper.get_json_data(url)
print(str_json)
# dic_json = json.loads(str_json.decode('utf-8'))
