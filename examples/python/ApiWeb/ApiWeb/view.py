# -*- coding: utf-8 -*-
from django.http import HttpResponse
from django.shortcuts import render
import urllib.request
import urllib
import json
from .config import Config
from .RequestHelper import RequestHelper


def index(request):
    request.encoding = 'utf-8'
    context = {'Title': "API Search"}
    if 'CnId' in request.GET:
        context['CnId'] = request.GET['CnId']
    return render(request, 'index.html', context)


def search(request):
    request.encoding = 'utf-8'

    cn_id = request.GET['CnId']
    # start_date = request.GET['StartDate']
    # end_date = request.GET['EndDate']

    if cn_id == '':
        return render(request, "index.html", {'Title': 'API Search'})

    url = Config.Url_Search_By_CnId + cn_id
    str_json = RequestHelper.get_json_data(url)
    dic_json = json.loads(str_json.decode('utf-8'))

    for release in dic_json['releases']:
        if len(release['parties']):
            release['supplier'] = (release['parties'])[0]
        if len(release['contracts']):
            release['contract'] = (release['contracts'])[0]

    return render(request, 'searchApiResult.html', {'data': dic_json, 'Title': 'API Search Result'})


# Just Test
def hello(request):
    request.encoding = 'utf-8'

    cn_id = request.GET['CnId']
    url = "https://rrqcsg42vk.execute-api.ap-southeast-2.amazonaws.com/poc/ocds/findById/" + cn_id
    data = {''}

    strJson = RequestHelper.get_json_data(url)
    dicJson = eval(strJson)
    # print(release.__dict__.uri)

    context = dicJson
    # context['hello'] = 'Hello World!'
    return render(request, 'hello.html', context)
