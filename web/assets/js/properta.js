jQuery(function(jQuery) {
		jQuery('.map .property-filter').show();

    function InitCarousel() {

        if (jQuery('.carousel .content ul').length !== 0) {
            jQuery('.carousel .content ul').carouFredSel({
                scroll: {
                    items: 1
                },
                auto: false,
                items: {
                    minimum: 1,
                    width: 145
                },
                next: {
                    button: '#carousel-next',
                    key: 'right'
                },
                prev: {
                    button: '#carousel-prev',
                    key: 'left'
                }
            });
        }

        if (jQuery('.carousel-wrapper .content ul').length !== 0) {
            jQuery('.carousel-wrapper .content ul').carouFredSel({
                scroll: {
                    items: 1
                },
                auto: false,
                items: {
                    minimum: 1
                },
                next: {
                    button: '#carousel-next',
                    key: 'right'
                },
                prev: {
                    button: '#carousel-prev',
                    key: 'left'
                }
            });
        }
    }

    InitCarousel();
});

jQuery(document).ready(function(jQuery) {    
    jQuery('input[type=checkbox]').not('.no-ezmark').ezMark();
    jQuery('input[type=radio]').not('.no-ezmark').ezMark();

    jQuery('.properties-grid .property .title').hover(function() {
        jQuery(this).closest('.property').addClass('hover');
    }, function() {
        jQuery(this).closest('.property').removeClass('hover');
    });

    jQuery('.property-filter .property-types .property-type').live('click', function(e) {
        e.preventDefault();
        if (jQuery(this).hasClass('active')) {
            jQuery(this).removeClass('active');
            jQuery('input[type=checkbox]', this).attr('checked', null).change();
        } else {
            jQuery(this).addClass('active');
            jQuery('input[type=checkbox]', this).attr('checked', 'checked').change();
        }
    });

    jQuery('.property-filter .property-types').attr('style', '');
    jQuery('.property-filter .property-types').bxSlider({
        slideWidth: 180,
        infiniteLoop: false,
        moveSlides: 1,
        minSlides: 1,
        maxSlides: 6,
        pager: false,
        hideControlOnEnd: true,
        oneToOneTouch: false
    });




    jQuery('.bxslider').bxSlider({
	    auto: true,
        slideWidth: 180,
        moveSlides: 1,
        minSlides: 1,
        maxSlides: 4,
        slideMargin: 20,
        infiniteLoop: false,
        hideControlOnEnd: true,
        pager: false
    });

    InitSubmissionProgressBar();
    InitChosen();
    InitPropertyCarousel();

    // @todo - what was purpose of this ?
	//InitImageSlider();

    function InitPropertyCarousel() {
        jQuery('.property-detail .gallery .content img').on({
            click: function(e) {
                var src = jQuery(this).attr('src');
                var img = jQuery(this).closest('.gallery').find('.preview img');

                img.attr('src', src);

                jQuery('.property-detail .gallery .content li').each(function() {
                    jQuery(this).removeClass('active');
                });

                jQuery(this).closest('li').addClass('active');
            }
        });
        jQuery('.property-detail .gallery .content a').on({
            click: function(e) {
                e.preventDefault();
            }
        })
    }

    function InitChosen() {
        jQuery('select.make-chosen').each(function(index) {
            jQuery(this).chosen({
                disable_search_threshold: 20
            });
        })
    }

	function InitImageSlider() {
		jQuery('.iosSlider').iosSlider({
			desktopClickDrag: true,
			snapToChildren: true,
			infiniteSlider: true,
			navSlideSelector: '.slider .navigation li',
			onSlideComplete: function(args) {
				if(!args.slideChanged) return false;

				jQuery(args.sliderObject).find('.slider-info').attr('style', '');

				jQuery(args.currentSlideObject).find('.slider-info').animate({
					left: '15px',
					opacity: '.9'
				}, 'easeOutQuint');
			},
			onSliderLoaded: function(args) {
				jQuery(args.sliderObject).find('.slider-info').attr('style', '');

				jQuery(args.currentSlideObject).find('.slider-info').animate({
					left: '15px',
					opacity: '.9'
				}, 'easeOutQuint');
			},
			onSlideChange: function(args) {
				jQuery('.slider .navigation li').removeClass('active');
				jQuery('.slider .navigation li:eq(' + (args.currentSlideNumber - 1) + ')').addClass('active');
			},
			autoSlide: true,
			scrollbar: true,
			scrollbarContainer: '.sliderContainer .scrollbarContainer',
			scrollbarMargin: '0',
			scrollbarBorderRadius: '0',
			keyboardControls: true
		});
	}

    function InitSubmissionProgressBar() {
        jQuery('.submission-form .span4').hover(function() {
            var index = jQuery(this).index();
            jQuery(this).addClass('active');
            jQuery('.progressbar .number').eq(index).addClass('active');

        }, function() {
            var index = jQuery(this).index();
            jQuery(this).removeClass('active');
            jQuery('.progressbar .number').eq(index).removeClass('active');
        });

        jQuery('.progressbar .item').hover(function() {
            var index = jQuery(this).index();
            jQuery('.number', this).addClass('active');
            jQuery('.submission-form .span4').eq(index).addClass('active');

        }, function() {
            var index = jQuery(this).index();
            jQuery('.number', this).removeClass('active');
            jQuery('.submission-form .span4').eq(index).removeClass('active');
        });
    }
});

