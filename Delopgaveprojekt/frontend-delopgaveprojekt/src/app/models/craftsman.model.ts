import { ToolBox } from "./toolbox.model";

export class Craftsman {
  constructor(
    public haandvaerkerId: number,
    public hvAnsaettelsedato: Date,
    public hvEfternavn: string,
    public hvFagomraade: string,
    public hvFornavn: string,
    public vaerktoejskasse: ToolBox[]
  ) {}
}
