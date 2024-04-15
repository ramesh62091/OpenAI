import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { getEnvironmentData } from 'worker_threads';

@Injectable({
  providedIn: 'root'
})
export class OpenAIService {

  constructor(private http:HttpClient) { }

  getData(input: string): Observable < any > {
    return this.http.get('http://localhost:5299/api/OpenAI?input=' + input, {
        responseType: 'text'
    });
}
}
