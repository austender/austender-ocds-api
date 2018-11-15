# -*- coding: utf-8 -*-

from django.shortcuts import render
import json
from ApiWeb.config import Config
from ApiWeb.RequestHelper import RequestHelper
import time
import pytz
import datetime
import urllib.error


def CnIdSearch(request):
    request.encoding = 'utf-8'

    cn_id = request.GET['CnId']
    # start_date = request.GET['StartDate']
    # end_date = request.GET['EndDate']

    if cn_id == '':
        return render(request, "CnIdSearch.html", {'Title': 'API Search By CN ID'})

    url = Config.Url_Search_By_CnId + cn_id
    str_json = RequestHelper.get_json_data(url)
    dic_json = json.loads(str_json.decode('utf-8'))

    data = {}

    if 'errorCode' in dic_json:
        data['message'] = dic_json['message']
        data['errorCode'] = dic_json['errorCode']
    else:
        for release in dic_json['releases']:
            if len(release['parties']):
                release['supplier'] = (release['parties'])[0]
            if len(release['contracts']):
                release['contract'] = (release['contracts'])[0]
        data['data'] = dic_json
    data['Title'] = 'API Search Result'
    print(data)
    return render(request, 'searchApiResult.html', data)


def DateRangeSearch(request):
    request.encoding = 'utf-8'

    start_date = request.GET['DateStart']
    end_date = request.GET['DateEnd']

    if start_date == '' or end_date == '':
        return render(request, "DateRangeSearch.html", {'Title': 'API Search By DateRange'})

    start_date = time.strptime(start_date, '%m/%d/%Y')
    start_date = time.strftime("%Y-%m-%dT%H:%M:%SZ", start_date)
    end_date = time.strptime(end_date, '%m/%d/%Y')
    end_date = time.strftime("%Y-%m-%dT%H:%M:%SZ", end_date)

    url = Config.Url_Search_By_DateRange + start_date + "/" + end_date
    try:
        str_json = RequestHelper.get_json_data(url)
        dic_json = json.loads(str_json.decode('utf-8'))
    except urllib.error.URLError as e:
        data = {'errorCode': e.code, 'message': 'No Records found', 'Title': 'API Search Result'}
        return render(request, 'searchApiResult.html', data)

    for release in dic_json['releases']:
        if len(release['parties']):
            release['supplier'] = (release['parties'])[0]
        if len(release['contracts']):
            release['contract'] = (release['contracts'])[0]

    return render(request, 'searchApiResult.html', {'data': dic_json, 'Title': 'API Search Result'})
