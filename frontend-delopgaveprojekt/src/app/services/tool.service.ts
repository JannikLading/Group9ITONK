
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Tool } from '../models/tool.model';

@Injectable()
export class ToolService {

    constructor(private http: HttpClient) { }

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        })
    };

    getTool(toolId: number): Observable<Tool> {
        const url = environment.ENDPOINT.TOOL + '/' + toolId;
        return this.http.get<Tool>(url, this.httpOptions);
    }

    getTools(): Observable<Array<Tool>> {
        const url = environment.ENDPOINT.TOOL
        return this.http.get<Array<Tool>>(url, this.httpOptions);
    }

    updateTool(toolId: number, dto: Tool): Observable<Tool> {
        const url = environment.ENDPOINT.TOOL + '/' + toolId;
        return this.http.put<Tool>(url, dto, this.httpOptions);
    }

    createTool(tool: Tool): Observable<Tool> {
        const url = environment.ENDPOINT.TOOL;
        return this.http.post<Tool>(url, tool, this.httpOptions);
    }

    deleteTool(id: Number) {
        const url = environment.ENDPOINT.TOOL + "/" + id;
        return this.http.delete(url, this.httpOptions);
    }
}


