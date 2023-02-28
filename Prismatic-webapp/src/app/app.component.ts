import { Component, OnInit, ViewChild } from '@angular/core';
import { Title } from '@angular/platform-browser';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'

})
export class AppComponent implements OnInit{
  constructor(
    title: Title
  ) {
    title.setTitle('Prismatic Pandemonium')
  }
  ngOnInit(): void {
    // if(this.player_hand === null)
    //   return

    // let sexo = new Array(this.player_hand.childNodes)

    // sexo.forEach(element => {
    //    element.item = this.player_hand = (globalEvent:GlobalEventHandlers, ev: MouseEvent) => {

    //   }
    // });
    
  }
    deck = [
    "../assets/blue0.png",
    "../assets/red12.png",
    "../assets/red5.png",
    "../assets/green0.png",
    "../assets/green1.png",
    "../assets/blue5.png",
    "../assets/yellow4.png",]

    @ViewChild("player_hand") player_hand : HTMLDivElement | null = null

}