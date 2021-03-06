import { Component, OnInit } from "@angular/core";
import { ToolService } from "../services/tool.service";
import { ToolBoxService } from "../services/toolbox.service";
import { CraftsmanService } from "../services/craftsman.service";
import { Tool } from "../models/tool.model";
import { ToolBox } from "../models/toolbox.model";
import { Craftsman } from "../models/craftsman.model";

@Component({
  selector: "app-show-items",
  templateUrl: "./show-items.component.html",
  styleUrls: ["./show-items.component.css"]
})
export class ShowItemsComponent implements OnInit {
  tools: Tool[];
  toolboxes: ToolBox[];
  craftsmen: Craftsman[];

  constructor(
    private toolService: ToolService,
    private toolboxService: ToolBoxService,
    private craftsmanService: CraftsmanService
  ) { }

  ngOnInit(): void {
    this.toolService.getTools().subscribe(res => this.tools = res);
    this.toolboxService.getToolBoxes().subscribe(res => this.toolboxes = res);
    this.craftsmanService.getCraftsmen().subscribe(res => {
      this.craftsmen = res;
    });
  }

  deleteToolBox(tbx: ToolBox) {
    this.toolboxService.deleteToolBox(tbx.vtkId).subscribe(res => console.log(res));
  }

  deleteTool(tool: Tool) {
    this.toolService.deleteTool(tool.vtId).subscribe(res => console.log(res));
  }

  deleteCraftman(man: Craftsman) {
    this.craftsmanService.deleteCraftsman(man.haandvaerkerId).subscribe(res => console.log(res));
  }

}
