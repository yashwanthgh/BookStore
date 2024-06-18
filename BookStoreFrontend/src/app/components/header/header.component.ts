import { Component, OnInit } from '@angular/core';
import { MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';
import { CART_ICON, HEART_ICON, PROFILE_ICON, SEARCH_ICON, STAR_ICON } from 'src/assets/svg-icons';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private iconRegistry: MatIconRegistry, private sanitizer: DomSanitizer) { 

    iconRegistry.addSvgIconLiteral("cart-icon", sanitizer.bypassSecurityTrustHtml(CART_ICON));
    iconRegistry.addSvgIconLiteral("profile-icon", sanitizer.bypassSecurityTrustHtml(PROFILE_ICON));
    iconRegistry.addSvgIconLiteral("search-icon", sanitizer.bypassSecurityTrustHtml(SEARCH_ICON));
    iconRegistry.addSvgIconLiteral('heart-icon', sanitizer.bypassSecurityTrustHtml(HEART_ICON));
    iconRegistry.addSvgIconLiteral('star-icon', sanitizer.bypassSecurityTrustHtml(STAR_ICON));

  }

  ngOnInit(): void {
  }

}
