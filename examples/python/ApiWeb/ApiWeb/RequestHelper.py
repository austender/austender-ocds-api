import urllib.request
import urllib
import ssl

ssl._create_default_https_context = ssl._create_unverified_context


class RequestHelper:
    @classmethod
    def get_json_data(cls, url):
        response = urllib.request.urlopen(url)  # Manual encoding required
        response.encoding = 'utf-8'
        result = response.read()
        return result
