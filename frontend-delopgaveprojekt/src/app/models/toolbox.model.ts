import { Tool } from "./tool.model";

export class ToolBox {
  constructor(
    public vtkId: number,
    public vtkAnskaffet: Date,
    public vtkFabrikat: string,
    public vtkModel: string,
    public vtkSerienummer: string,
    public vtkFarve: string,
    public Vaerktoej: Tool[],
    public vtkEjesAf?: number
  ) {}
}
