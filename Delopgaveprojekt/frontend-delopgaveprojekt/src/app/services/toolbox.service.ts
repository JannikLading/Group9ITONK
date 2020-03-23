
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { ToolBox } from '../models/toolbox.model';

@Injectable()
export class ToolBoxService {

    constructor(private http: HttpClient) { }

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        })
    };

    getToolBox(toolboxId: number): Observable<ToolBox> {
        const url = environment.ENDPOINT.TOOLBOX + '/' + toolboxId;
        return this.http.get<ToolBox>(url, this.httpOptions);
    }

    getToolBoxes(): Observable<Array<ToolBox>> {
        const url = environment.ENDPOINT.TOOLBOX
        return this.http.get<Array<ToolBox>>(url, this.httpOptions);
    }

    updateToolBox(toolId: number, dto: ToolBox): Observable<ToolBox> {
        const url = environment.ENDPOINT.TOOLBOX + '/' + toolId;
        return this.http.put<ToolBox>(url, dto, this.httpOptions);
    }

    createToolBox(toolBox: ToolBox): Observable<ToolBox> {
        const url = environment.ENDPOINT.TOOLBOX;
        return this.http.post<ToolBox>(url, toolBox, this.httpOptions);
    }

    deleteToolBox(id: Number) {
        const url = environment.ENDPOINT.TOOLBOX + "/" + id;
        return this.http.delete(url, this.httpOptions);
    }
}


