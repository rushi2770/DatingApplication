import { Component, OnInit } from '@angular/core';
import {ValueService} from '../value.service';
import { Http, Response } from '@angular/http';

import { IValue } from '../value';


@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})

export class ValueComponent implements OnInit {

  valuesList: IValue[] = [];
  name = 'rushi';
  constructor(private _valueService: ValueService) { }

  ngOnInit() {
  this.getValuesFromService();
  }

  getValuesFromService() {
    this._valueService.getValues().subscribe((valuesData: IValue[]) => this.valuesList = valuesData);
       }
  }

