import ssl
import urllib
import urllib.request
import socket
from ApiWeb.config import Config
from ApiWeb.RequestHelper import RequestHelper
import time
import pytz
import datetime
from datetime import  timezone
import json
import urllib.request
import urllib.error


try:
    url='https://dev-tenders-ocds-api.tenders.gov.au/dev/ocds/findByDates/contractPublished/2016-03-01T07:20:10Z/2018-06-06T05:45:00Z'
    str_json = RequestHelper.get_json_data(url)
    print (str_json)
    #dic_json = json.loads(str_json.decode('utf-8'))
except urllib.error.URLError as e:
    print(e.reason)
