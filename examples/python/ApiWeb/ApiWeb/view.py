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


def CnIdSearch(request):
    request.encoding = 'utf-8'
    context = {'Title': "API Search By CN ID"}
    if 'CnId' in request.GET:
        context['CnId'] = request.GET['CnId']
    return render(request, 'CnIdSearch.html', context)


def DateRangeSearch(request):
    request.encoding = 'utf-8'
    context = {'Title': "API Search By DateRange"}
    return render(request, 'DateRangeSearch.html', context)


# Just Test
def hello(request):
    request.encoding = 'utf-8'

    return HttpResponse("Hello Python")
