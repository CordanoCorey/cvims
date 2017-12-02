import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'cv-tile',
  templateUrl: './tile.component.html',
  styleUrls: ['./tile.component.scss']
})
export class TileComponent implements OnInit {

  @Input() title = '';

  constructor() { }

  ngOnInit() {
  }

}
