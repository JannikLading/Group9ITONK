export class Tool {
  constructor(
    public vtId: number,
    public vtAnskaffet: Date,
    public vtFabrikat: string,
    public vtModel: string,
    public vtSerienummer: string,
    public vtType: string,
    public liggerIvtk?: number
  ) { }
}
