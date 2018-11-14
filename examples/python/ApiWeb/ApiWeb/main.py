import ssl
import urllib
import urllib.request
import socket
from ApiWeb.config import Config
from ApiWeb.RequestHelper import RequestHelper

url = Config.Url_Search_By_CnId

result = RequestHelper.get_json_data(url)
print(result)
