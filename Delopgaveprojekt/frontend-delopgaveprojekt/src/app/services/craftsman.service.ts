import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { Observable } from "rxjs";
import { HttpClient, HttpParams, HttpHeaders } from "@angular/common/http";
import { Craftsman } from "../models/craftsman.model";

@Injectable()
export class CraftsmanService {
  constructor(private http: HttpClient) {
  }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };


  getCraftsman(craftsmanId: number): Observable<Craftsman> {
    const url = environment.ENDPOINT.CRAFTSMAN + "/" + craftsmanId;
    return this.http.get<Craftsman>(url, this.httpOptions);
  }

  getCraftsmen(): Observable<Array<Craftsman>> {
    const url = environment.ENDPOINT.CRAFTSMAN;
    return this.http.get<Array<Craftsman>>(url, this.httpOptions);
  }

  updateCraftsman(craftsmanId: number, dto: Craftsman): Observable<Craftsman> {
    const url = environment.ENDPOINT.CRAFTSMAN + "/" + craftsmanId;
    return this.http.put<Craftsman>(url, dto, this.httpOptions);
  }

  createCraftsman(craftsman: Craftsman): Observable<Craftsman> {
    const url = environment.ENDPOINT.CRAFTSMAN;
    return this.http.post<Craftsman>(url, craftsman, this.httpOptions);
  }

  deleteCraftsman(id: Number) {
    const url = environment.ENDPOINT.CRAFTSMAN + "/" + id;
    return this.http.delete(url, this.httpOptions);
  }

}
