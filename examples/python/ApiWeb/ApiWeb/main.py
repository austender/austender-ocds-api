from ApiWeb.RequestHelper import RequestHelper
from ApiWeb.config import Config
import json


url = Config.Url_Search_By_CnId + "CN2990589"
str_json = RequestHelper.get_json_data(url)
dic_json = json.loads(str_json.decode('utf-8'))

data = {}
print(dic_json)
if 'errorCode' in dic_json:
    data['message'] = dic_json['message']
    data['errorCode'] = dic_json['errorCode']
else:
    index = 0
    amendments=list()
    cn={}
    for release in dic_json['releases']:
        if index == 0:
            if len(release['parties']):
                release['supplier'] = (release['parties'])[0]
            if len(release['contracts']):
                release['contract'] = (release['contracts'])[0]
                (release["contract"])["amendments"]=[]
        else:
            amendment = ((release['contracts'])[0])["amendments"][0]
            amendments.append(amendment)
        index += 1
    cn=dic_json["releases"][0]
    (cn["contract"])["amendments"]=amendments
    #(((dic_json["releases"])[0])["contract"])["amendments"]=amendments
data['releases']=[]
data['releases'].append(cn)
print(cn)

print("*********")
url = Config.Url_Search_By_DateRange + "2018-12-03T01:00:00Z/2018-12-07T01:00:00Z"
str_json = RequestHelper.get_json_data(url)
dic_json = json.loads(str_json.decode('utf-8'))

index = 0
amendments = []
cns = list()
print(dic_json["releases"])
for release in dic_json['releases']:
    if (release["tag"])[0] == "contract":
        if amendments:
            (cns[index-1])["contract"]["amendments"] = amendments
            amendments = [];
        if len(release['parties']):
            release['supplier'] = (release['parties'])[0]
        if len(release['contracts']):
            release['contract'] = (release['contracts'])[0]
        cn = release
        cns.append(cn)
        index += 1;
    else:
        amendment = ((release['contracts'])[0])["amendments"][0]
        amendments.append(amendment)
if amendments:
    (cns[index-1])["contract"]["amendments"] = amendments