function InfoBox(a) {
	a = a || {};
	google.maps.OverlayView.apply(this, arguments);
	this.content_ = a.content || "";
	this.disableAutoPan_ = a.disableAutoPan || false;
	this.maxWidth_ = a.maxWidth || 0;
	this.pixelOffset_ = a.pixelOffset || new google.maps.Size(0, 0);
	this.position_ = a.position || new google.maps.LatLng(0, 0);
	this.zIndex_ = a.zIndex || null;
	this.boxStyle_ = a.boxStyle || {};
	this.closeBoxMargin_ = a.closeBoxMargin || "2px";
	this.closeBoxURL_ = a.closeBoxURL || "http://www.google.com/intl/en_us/mapfiles/close.gif";
	if (a.closeBoxURL === "") {
		this.closeBoxURL_ = ""
	}
	this.infoBoxClearance_ = a.infoBoxClearance || new google.maps.Size(1, 1);
	this.isHidden_ = a.isHidden || false;
	this.pane_ = a.pane || "floatPane";
	this.div_ = null;
	this.closeListener_ = null;
	this.fixedWidthSet_ = null
}
InfoBox.prototype = new google.maps.OverlayView();
InfoBox.prototype.createInfoBoxDiv_ = function () {
	var a;
	if (!this.div_) {
		this.div_ = document.createElement("div");
		this.setBoxStyle_();
		this.div_.style.position = "absolute";
		this.div_.style.visibility = 'hidden';
		if (this.zIndex_ !== null) {
			this.div_.style.zIndex = this.zIndex_
		}
		this.div_.innerHTML = this.getCloseBoxImg_() + this.content_;
		this.getPanes()[this.pane_].appendChild(this.div_);
		this.addClickHandler_();
		if (this.div_.style.width) {
			this.fixedWidthSet_ = true
		} else {
			if (this.maxWidth_ !== 0 && this.div_.offsetWidth > this.maxWidth_) {
				this.div_.style.width = this.maxWidth_;
				this.div_.style.overflow = "auto";
				this.fixedWidthSet_ = true
			} else {
				a = this.getBoxWidths_();
				this.div_.style.width = (this.div_.offsetWidth - a.left - a.right) + "px";
				this.fixedWidthSet_ = false
			}
		}
		this.panBox_(this.disableAutoPan_);
		google.maps.event.trigger(this, "domready")
	}
};
InfoBox.prototype.getCloseBoxImg_ = function () {
	var a = "";
	if (this.closeBoxURL_ !== "") {
		a = "<img";
		a += " src='" + this.closeBoxURL_ + "'";
		a += " align=right";
		a += " style='";
		a += " position: relative;";
		a += " cursor: pointer;";
		a += " margin: " + this.closeBoxMargin_ + ";";
		a += "'>"
	}
	return a
};
InfoBox.prototype.addClickHandler_ = function () {
	var a;
	if (this.closeBoxURL_ !== "") {
		a = this.div_.firstChild;
		this.closeListener_ = google.maps.event.addDomListener(a, 'click', this.getCloseClickHandler_())
	} else {
		this.closeListener_ = null
	}
};
InfoBox.prototype.getCloseClickHandler_ = function () {
	var a = this;
	return function () {
		a.close();
		google.maps.event.trigger(a, "closeclick")
	}
};
InfoBox.prototype.panBox_ = function (A) {
	if (!A) {
		var d = this.getMap();
		var v = d.getBounds();
		var i = d.getDiv();
		var g = i.offsetWidth;
		var j = i.offsetHeight;
		var b = v.toSpan();
		var h = b.lng();
		var r = b.lat();
		var o = h / g;
		var s = r / j;
		var t = v.getSouthWest().lng();
		var m = v.getNorthEast().lng();
		var e = v.getNorthEast().lat();
		var y = v.getSouthWest().lat();
		var a = this.position_;
		var u = this.pixelOffset_.width;
		var w = this.pixelOffset_.height;
		var n = this.infoBoxClearance_.width;
		var p = this.infoBoxClearance_.height;
		var z = a.lng() + (u - n) * o;
		var x = a.lng() + (u + this.div_.offsetWidth + n) * o;
		var k = a.lat() - (w - p) * s;
		var q = a.lat() - (w + this.div_.offsetHeight + p) * s;
		var l = (z < t ? t - z: 0) + (x > m ? m - x: 0);
		var f = (k > e ? e - k: 0) + (q < y ? y - q: 0);
		if (! (f === 0 && l === 0)) {
			var c = d.getCenter();
			d.setCenter(new google.maps.LatLng(c.lat() - f, c.lng() - l))
		}
	}
};
InfoBox.prototype.setBoxStyle_ = function () {
	var i;
	var a = this.boxStyle_;
	for (i in a) {
		if (a.hasOwnProperty(i)) {
			this.div_.style[i] = a[i]
		}
	}
	if (typeof this.div_.style.opacity !== "undefined") {
		this.div_.style.filter = "alpha(opacity=" + (this.div_.style.opacity * 100) + ")"
	}
};
InfoBox.prototype.getBoxWidths_ = function () {
	var c;
	var a = {
		top: 0,
		bottom: 0,
		left: 0,
		right: 0
	};
	var b = this.div_;
	if (document.defaultView && document.defaultView.getComputedStyle) {
		c = b.ownerDocument.defaultView.getComputedStyle(b, "");
		if (c) {
			a.top = parseInt(c.borderTopWidth, 10) || 0;
			a.bottom = parseInt(c.borderBottomWidth, 10) || 0;
			a.left = parseInt(c.borderLeftWidth, 10) || 0;
			a.right = parseInt(c.borderRightWidth, 10) || 0
		}
	} else if (document.documentElement.currentStyle) {
		if (b.currentStyle) {
			a.top = parseInt(b.currentStyle.borderTopWidth, 10) || 0;
			a.bottom = parseInt(b.currentStyle.borderBottomWidth, 10) || 0;
			a.left = parseInt(b.currentStyle.borderLeftWidth, 10) || 0;
			a.right = parseInt(b.currentStyle.borderRightWidth, 10) || 0
		}
	}
	return a
};
InfoBox.prototype.onRemove = function () {
	if (this.div_) {
		this.div_.parentNode.removeChild(this.div_);
		this.div_ = null
	}
};
InfoBox.prototype.draw = function () {
	this.createInfoBoxDiv_();
	var a = this.getProjection().fromLatLngToDivPixel(this.position_);
	this.div_.style.left = (a.x + this.pixelOffset_.width) + "px";
	this.div_.style.top = (a.y + this.pixelOffset_.height) + "px";
	if (this.isHidden_) {
		this.div_.style.visibility = 'hidden'
	} else {
		this.div_.style.visibility = "visible"
	}
};
InfoBox.prototype.setOptions = function (a) {
	if (typeof a.boxStyle !== "undefined") {
		this.boxStyle_ = a.boxStyle;
		this.setBoxStyle_()
	}
	if (typeof a.content !== "undefined") {
		this.setContent(a.content)
	}
	if (typeof a.disableAutoPan !== "undefined") {
		this.disableAutoPan_ = a.disableAutoPan
	}
	if (typeof a.maxWidth !== "undefined") {
		this.maxWidth_ = a.maxWidth
	}
	if (typeof a.pixelOffset !== "undefined") {
		this.pixelOffset_ = a.pixelOffset
	}
	if (typeof a.position !== "undefined") {
		this.setPosition(a.position)
	}
	if (typeof a.zIndex !== "undefined") {
		this.setZIndex(a.zIndex)
	}
	if (typeof a.closeBoxMargin !== "undefined") {
		this.closeBoxMargin_ = a.closeBoxMargin
	}
	if (typeof a.closeBoxURL !== "undefined") {
		this.closeBoxURL_ = a.closeBoxURL
	}
	if (typeof a.infoBoxClearance !== "undefined") {
		this.infoBoxClearance_ = a.infoBoxClearance
	}
	if (typeof a.isHidden !== "undefined") {
		this.isHidden_ = a.isHidden
	}
	if (this.div_) {
		this.draw()
	}
};
InfoBox.prototype.setContent = function (a) {
	this.content_ = a;
	if (this.div_) {
		if (this.closeListener_) {
			google.maps.event.removeListener(this.closeListener_);
			this.closeListener_ = null
		}
		if (!this.fixedWidthSet_) {
			this.div_.style.width = ""
		}
		this.div_.innerHTML = this.getCloseBoxImg_() + a;
		if (!this.fixedWidthSet_) {
			this.div_.style.width = this.div_.offsetWidth + "px";
			this.div_.innerHTML = this.getCloseBoxImg_() + a
		}
		this.addClickHandler_()
	}
	google.maps.event.trigger(this, "content_changed")
};
InfoBox.prototype.setPosition = function (a) {
	this.position_ = a;
	if (this.div_) {
		this.draw()
	}
	google.maps.event.trigger(this, "position_changed")
};
InfoBox.prototype.setZIndex = function (a) {
	this.zIndex_ = a;
	if (this.div_) {
		this.div_.style.zIndex = a
	}
	google.maps.event.trigger(this, "zindex_changed")
};
InfoBox.prototype.getContent = function () {
	return this.content_
};
InfoBox.prototype.getPosition = function () {
	return this.position_
};
InfoBox.prototype.getZIndex = function () {
	return this.zIndex_
};
InfoBox.prototype.show = function () {
	this.isHidden_ = false;
	this.div_.style.visibility = "visible"
};
InfoBox.prototype.hide = function () {
	this.isHidden_ = true;
	this.div_.style.visibility = "hidden"
};
InfoBox.prototype.open = function (b, a) {
	if (a) {
		this.position_ = a.getPosition()
	}
	this.setMap(b);
	if (this.div_) {
		this.panBox_()
	}
};
InfoBox.prototype.close = function () {
	if (this.closeListener_) {
		google.maps.event.removeListener(this.closeListener_);
		this.closeListener_ = null
	}
	this.setMap(null)
};