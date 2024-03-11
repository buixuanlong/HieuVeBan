/* To avoid CSS expressions while still supporting IE 7 and IE 6, use this script */
/* The script tag referencing this file must be placed before the ending body tag. */

/* Use conditional comments in order to target IE 7 and older:
	<!--[if lt IE 8]><!-->
	<script src="ie7/ie7.js"></script>
	<!--<![endif]-->
*/

(function() {
	function addIcon(el, entity) {
		var html = el.innerHTML;
		el.innerHTML = '<span style="font-family: \'uehfonts\'">' + entity + '</span>' + html;
	}
	var icons = {
		'ueh-guide': '&#xe91f;',
		'ueh-audit': '&#xe91d;',
		'ueh-role': '&#xe91a;',
		'ueh-review': '&#xe919;',
		'ueh-customer': '&#xe918;',
		'ueh-category': '&#xe917;',
		'ueh-poster': '&#xe916;',
		'ueh-accept': '&#xe915;',
		'ueh-invoices': '&#xe900;',
		'ueh-logo': '&#x1f31d;',
		'ueh-sms': '&#xe901;',
		'ueh-email': '&#xe902;',
		'ueh-attach_money': '&#xe913;',
		'ueh-money_off': '&#xe914;',
		'ueh-keyboard_arrow_down': '&#xe903;',
		'ueh-keyboard_arrow_left': '&#xe904;',
		'ueh-keyboard_arrow_right': '&#xe906;',
		'ueh-keyboard_arrow_up': '&#xe907;',
		'ueh-arrow_back': '&#xe908;',
		'ueh-arrow_drop_down': '&#xe909;',
		'ueh-arrow_drop_up': '&#xe90a;',
		'ueh-arrow_forward': '&#xe90b;',
		'ueh-arrow_upward': '&#xe90c;',
		'ueh-subdirectory_arrow_left': '&#xe90d;',
		'ueh-subdirectory_arrow_right': '&#xe90e;',
		'ueh-arrow_downward': '&#xe90f;',
		'ueh-arrow_left': '&#xe910;',
		'ueh-arrow_right': '&#xe911;',
		'ueh-notifications_none': '&#xe91b;',
		'ueh-notifications_active': '&#xe91c;',
		'ueh-person': '&#xe91e;',
		'ueh-dashboard': '&#xe912;',
		'ueh-edit': '&#xe905;',
		'ueh-user': '&#xe971;',
		'ueh-pie-chart': '&#xe99a;',
		'ueh-stats-dots': '&#xe99b;',
		'ueh-stats-bars': '&#xe99c;',
		'ueh-delete': '&#xe9ac;',
		'ueh-view': '&#xe9ce;',
		'ueh-unview': '&#xe9d1;',
		'ueh-info': '&#xea0c;',
		'0': 0
		},
		els = document.getElementsByTagName('*'),
		i, c, el;
	for (i = 0; ; i += 1) {
		el = els[i];
		if(!el) {
			break;
		}
		c = el.className;
		c = c.match(/ueh-[^\s'"]+/);
		if (c && icons[c[0]]) {
			addIcon(el, icons[c[0]]);
		}
	}
}());
