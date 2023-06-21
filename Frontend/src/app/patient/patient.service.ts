import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  constructor(private http: HttpClient) { }

  GetPatientsDetails(currentpage: number) {
    return this.http.get(`https://localhost:7170/api/PatientController/GetPatientsDetails?pageNumber=${currentpage}&pageSize=10`)
  }

  GetPatientEventsSummary( patientId:number){
    return this.http.get(`https://localhost:7170/api/PatientController/GetPatientEventsSummary?patientId=${patientId}`)
  }
}
