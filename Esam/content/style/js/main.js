//Scroll To Up

$(window).scroll(function() {
      if ($(this).scrollTop() > 350) {
        $('.go-up-footer').fadeIn();
      } else {
        $('.go-up-footer').fadeOut();
      }
    });

$(document).ready(function() {
      $(".go-up-footer").click(function() {
        $('html, body').animate({
          scrollTop: 0
        });
      });
    });


//active item support-cart 

$(".item-lsc").click(function(){
  $(".location-sc .item-lsc").removeClass("active-lsc");
  $(this).addClass("active-lsc");
});

//active item item bank
$(".item-bank").click(function(){
  $(".bank-selection .item-bank").removeClass("active-ib");
  $(this).addClass("active-ib");
});


$(document).ready(function(){
  

//Owl Product One
$('.owl-product-one').owlCarousel({

  autoplay: false,
  loop: false,
  slideSpeed: 100,
  paginationSpeed: 20,
  margin: 10,
  nav: false,
  smartSpeed: 800,
  dots: false,
  onChanged: owlProductOneChanged,
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 2
    },
    767: {
      items: 3
    },
    991: {
      items: 4
    },
    1200: {
      items: 5
    },
    1600: {
      items: 6
    }
  }
});
function owlProductOneChanged(event) {
  var pages = event.page.size;
  var item = event.item.index;
  var items = event.item.count;
  enditem = item + pages;

 
  

  if (enditem == items) {
    $("#nextcarousel-one").addClass("hide");

  } else {
    $("#nextcarousel-one").removeClass("hide");
  }
  if (item > 0) {
    $("#prevcarousel-one").addClass("show");
  } else {
    $("#prevcarousel-one").removeClass("show");
  }


}
var owl = $('.owl-product-one');
owl.owlCarousel();
$('#nextcarousel-one').click(function () {
  owl.trigger('next.owl.carousel', [800]);
});
$('#prevcarousel-one').click(function () {
  owl.trigger('prev.owl.carousel', [800]);
});


//Owl Product Two
$('.owl-product-two').owlCarousel({

  autoplay: false,
  loop: false,
  slideSpeed: 100,
  paginationSpeed: 20,
  margin: 10,
  nav: false,
  smartSpeed: 800,
  dots: false,
  onChanged: owlProductTwoChanged,
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 2
    },
    767: {
      items: 3
    },
    991: {
      items: 4
    },
    1200: {
      items: 5
    },
    1600: {
      items: 6
    }
  }
});
function owlProductTwoChanged(event) {
  var pages = event.page.size;
  var item = event.item.index;
  var items = event.item.count;
  enditem = item + pages;

  if (enditem == items) {
    $("#nextcarousel-two").addClass("hide");

  } else {
    $("#nextcarousel-two").removeClass("hide");
  }
  if (item > 0) {
    $("#prevcarousel-two").addClass("show");
  } else {
    $("#prevcarousel-two").removeClass("show");
  }


}
var owlTwo = $('.owl-product-two');
owlTwo.owlCarousel();
$('#nextcarousel-two').click(function () {
  owlTwo.trigger('next.owl.carousel', [800]);
});
$('#prevcarousel-two').click(function () {
  owlTwo.trigger('prev.owl.carousel', [800]);
});

//Owl Product Three
$('.owl-product-three').owlCarousel({

  autoplay: false,
  loop: false,
  slideSpeed: 100,
  paginationSpeed: 20,
  margin: 10,
  nav: false,
  smartSpeed: 800,
  dots: false,
  onChanged: owlProductThreeChanged,
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 2
    },
    767: {
      items: 3
    },
    991: {
      items: 4
    },
    1200: {
      items: 5
    },
    1600: {
      items: 6
    }
  }
});
function owlProductThreeChanged(event) {
  var pages = event.page.size;
  var item = event.item.index;
  var items = event.item.count;
  enditem = item + pages;

  if (enditem == items) {
    $("#nextcarousel-three").addClass("hide");

  } else {
    $("#nextcarousel-three").removeClass("hide");
  }
  if (item > 0) {
    $("#prevcarousel-three").addClass("show");
  } else {
    $("#prevcarousel-three").removeClass("show");
  }


}
var owlThree = $('.owl-product-three');
owlThree.owlCarousel();
$('#nextcarousel-three').click(function () {
  owlThree.trigger('next.owl.carousel', [800]);
});
$('#prevcarousel-three').click(function () {
  owlThree.trigger('prev.owl.carousel', [800]);
});



//Owl Product Four
$('.owl-product-four').owlCarousel({

  autoplay: false,
  loop: false,
  slideSpeed: 100,
  paginationSpeed: 20,
  margin: 10,
  nav: false,
  smartSpeed: 800,
  dots: false,
  onChanged: owlProductFourChanged,
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 2
    },
    767: {
      items: 3
    },
    991: {
      items: 4
    },
    1200: {
      items: 5
    },
    1600: {
      items: 6
    }
  }
});
function owlProductFourChanged(event) {
  var pages = event.page.size;
  var item = event.item.index;
  var items = event.item.count;
  enditem = item + pages;

  if (enditem == items) {
    $("#nextcarousel-four").addClass("hide");

  } else {
    $("#nextcarousel-four").removeClass("hide");
  }
  if (item > 0) {
    $("#prevcarousel-four").addClass("show");
  } else {
    $("#prevcarousel-four").removeClass("show");
  }


}
var owlFour = $('.owl-product-four');
owlFour.owlCarousel();
$('#nextcarousel-four').click(function () {
  owlFour.trigger('next.owl.carousel', [800]);
});
$('#prevcarousel-four').click(function () {
  owlFour.trigger('prev.owl.carousel', [800]);
});


$(".close-tabligh-bl").click(function(){
  $(".tabligh-bl").remove();
});

$(".close-tabligh-br").click(function(){
  $(".tabligh-br").remove();
});
  
  $('#small-image-product').owlCarousel({


      autoplay: false,
      loop: false,
      slideSpeed: 100,
      paginationSpeed: 20,
      margin: 10,
      nav: false,
      mouseDrag: false,
      smartSpeed: 800,
      dots: false,
      onChanged: owlProductOneChanged,
      responsive: {
        0: {
          items: 3
        },
        600: {
          items: 5
        },
        767: {
          items: 5
        },
        991: {
          items: 4
        },
        1200: {
          items: 5
        },
        1600: {
          items: 5
        }
      }
    });

  
  
  
  

});


//single product small image
$(document).ready(function(){
    var owl = $('#small-image-product');
    owl.owlCarousel();
    $('.next-small-img-product').click(function() {
      owl.trigger('next.owl.carousel', [800]);
    });
    $('.prev-small-img-product').click(function() {
      owl.trigger('prev.owl.carousel', [800]);
    });
  
});


//Time Clock

//owlcarousel-Product
//owlcarousel-Slider
    $(document).ready(function () {
        $('.owl-slider').owlCarousel({
          items: 1
          , margin: 10
          , autoHeight: true
          , animateOut: 'fadeOut'
          , animateIn: 'pulse'
        , });
      })
      




//for show and hide list notifications
$(document).ready(function(){
    $(".el-notifications").click(function(){
        $(".list-notifications").toggleClass("list-notifications-visible");
    });
});

//for show and hide slide menu
$(document).ready(function(){
    
    
    $("#menu-top-bar").click(function(){
        $("#box-login-top-bar").removeClass("open-slide");
        $("#box-search-top-bar").removeClass("open-slide");
        $("#box-menu-top-bar").toggleClass("open-slide");

        if($("#box-menu-top-bar").hasClass("open-slide")){
            $("body").addClass("overflow-y-hidden")
        }
        else {
            $("body").removeClass("overflow-y-hidden")
        }
        
    });
    
    
    $("#login-top-bar").click(function(){
        $("#box-search-top-bar").removeClass("open-slide");
        $("#box-menu-top-bar").removeClass("open-slide");
        $("#box-login-top-bar").toggleClass("open-slide");
        if($("#box-login-top-bar").hasClass("open-slide")){
            $("body").addClass("overflow-y-hidden")
        }
        else {
            $("body").removeClass("overflow-y-hidden")
        }
        
    });
    
    
    $("#search-top-bar").click(function(){
         $("#box-menu-top-bar").removeClass("open-slide");
        $("#box-login-top-bar").removeClass("open-slide");
            $("#box-search-top-bar").toggleClass("open-slide");
            if($("#box-search-top-bar").hasClass("open-slide")){
            $("body").addClass("overflow-y-hidden")
        }
        else {
            $("body").removeClass("overflow-y-hidden")
        }
            
    });
    
    
});

$(document).ready(function(){
    var navhtml = $(".for-inner-slide-nav").html();
    $(".inner-slide-nav").html(navhtml);
    
    var nav_top_html = $(".box-nav-top").html();
    $(".inner-slide-topmenu").html(nav_top_html);
    
    var box_login_html = $(".box-login").html();
    $(".inner-slide-login").html(box_login_html);
    
    var box_search_html = $(".box-search").html();
    $(".inner-slide-search").html(box_search_html);
    
    

    
});

//show menu in mobile
$(document).ready(function(){
    var navigation_1_li = $(".inner-slide-nav > .navigation-level-1 > li");
    var navigation_1_li_a = $(".inner-slide-nav > .navigation-level-1 > li > a");
    var navigation_2_li_a = $(".inner-slide-nav .navigation-level-2 > li > a");
//    $(navigation_1_li_a).attr("href","javascript:;");
    $(navigation_1_li_a).after("<span class='toggle-slide-menu'><span class='transition-01s'><i class='centerbox icon menu-sm-icon-left'></i></span></span>");
    $(navigation_2_li_a).after("<span class='toggle-slide-menu'><span class='transition-01s'><i class='centerbox icon menu-sm-icon-left'></i></span></span>");

    $(".navigation-level-1 > li > .toggle-slide-menu").click(function(){
        $(this).toggleClass("on-click");
        $(this).next().toggleClass("visibility-visible");
    });
    
    $(".navigation-level-2 > li > .toggle-slide-menu").click(function(){
        $(this).toggleClass("on-click");
        $(this).next().toggleClass("visibility-visible");
    });   
});


//check color single page
$(document).ready(function(){
        $(".color-single").click(function(){
            $(".color-single").removeClass("tik");
            $(this).addClass("tik");
            $(this).find("input[type='radio']").prop("checked",true);
        });
    });


$(document).ready(function(){
  $(".box-slide-nav .notification-toggle").click(function(){
      $(this).find(".toggle-login").toggleClass("active-th");
    });
});


//owl-wrapper change item class
    $(document).ready(function(){
        $(".box-small-img-product .owl-item .item").click(function(){
            $(".box-small-img-product .owl-item .item > a").removeClass("mz-thumb-selected");
            $(this).find("a").addClass("mz-thumb-selected");
        });
    });


//if mobile change to desktop hidden menu
    $(function() {
        function responsiveView() {
            var wSize = $(window).width();
            if (wSize > 767) {
                $("body").removeClass("overflow-y-hidden");
            }

            if (wSize < 768) {
                var length_open_slide = $(".open-slide").length;
                if(length_open_slide > 0){
                    $("body").addClass("overflow-y-hidden");
                }
            }
            
        }
        $(window).on('load', responsiveView);
        $(window).on('resize', responsiveView);
    });


//more-brief-introduction
    $(document).ready(function(){
        $(".more-brief-introduction").click(function(){
            $(this).parents(".box-brief-introduction").addClass("show-more-brief-introduction");
        });
    });

$(document).ready(function(){
  
//Timeto
$('#countdown-single').timeTo({
    timeTo: new Date(new Date('Sun Mar 6 2019 09:00:00 GMT+0330 (Iran Standard Time)')),
    displayDays: 2,
    displayCaptions: true,
    fontSize: 13,
    lang: "fa",
    captionSize: 12
});

  $('#aduction-ended').timeTo({
    timeTo: new Date(new Date('Sun Mar 2 2020 09:00:00 GMT+0330 (Iran Standard Time)')),
    displayDays: 2,
    displayCaptions: true,
    fontSize: 13,
    lang: "fa",
    captionSize: 12
});


$('#countdown-single-modal').timeTo({
    timeTo: new Date(new Date('Sun Mar 6 2019 09:00:00 GMT+0330 (Iran Standard Time)')),
    displayDays: 2,
    displayCaptions: true,
    fontSize: 13,
    lang: "fa",
    captionSize: 12
});
    $('#countdown-1').timeTo({
      seconds: 85100
      , displayHours: true
    });
    $('#countdown-2').timeTo({
      seconds: 17920
      , displayHours: true
    });
    $('#countdown-3').timeTo({
      seconds: 61020
      , displayHours: true
    });
    $('#countdown-4').timeTo({
      seconds: 21180
      , displayHours: true
    });
    $('#countdown-5').timeTo({
      seconds: 70150
      , displayHours: true
    });
    $('#countdown-6').timeTo({
      seconds: 82100
      , displayHours: true
    });
    $('#countdown-7').timeTo({
      seconds: 27920
      , displayHours: true
    });
    $('#countdown-8').timeTo({
      seconds: 31020
      , displayHours: true
    });
    $('#countdown-9').timeTo({
      seconds: 61180
      , displayHours: true
    });
    $('#countdown-10').timeTo({
      seconds: 48150
      , displayHours: true
    });
    $('#countdown-11').timeTo({
      seconds: 72100
      , displayHours: true
    });
    $('#countdown-12').timeTo({
      seconds: 19920
      , displayHours: true
    });
    $('#countdown-13').timeTo({
      seconds: 66020
      , displayHours: true
    });
    $('#countdown-14').timeTo({
      seconds: 28180
      , displayHours: true
    });
    $('#countdown-15').timeTo({
      seconds: 78150
      , displayHours: true
    });
    $('#countdown-16').timeTo({
      seconds: 85100
      , displayHours: true
    });
    $('#countdown-17').timeTo({
      seconds: 17920
      , displayHours: true
    });
    $('#countdown-18').timeTo({
      seconds: 61020
      , displayHours: true
    });
    $('#countdown-19').timeTo({
      seconds: 21180
      , displayHours: true
    });
    $('#countdown-20').timeTo({
      seconds: 70150
      , displayHours: true
    });

});


//active selectric
$(document).ready(function(){
   $('.selectric').selectric();
});

//Collapse Contact Us
 $(document).ready(function() {
      $('.treeCategory ul').hide();
      $('.liselector').click(function() {
        $(this).find('ul').slideToggle("fast");
        $(this).find('.CollapseIcon').toggleClass('glyphicon-plus-sign').toggleClass('glyphicon-minus-sign');
      });
    });

//Collapse AuctionList
$(document).ready(function(){
  $(".show-col").click(function(){
    $(this).parents(".box-collapse").removeClass("show-collapse");
    $(this).parents(".box-collapse").addClass("hide-collapse");
  });

  $(".hide-col").click(function(){
   $(this).parents(".box-collapse").removeClass("hide-collapse");
   $(this).parents(".box-collapse").addClass("show-collapse");
  });
});

//Active icheck Plugin For Page = AuctionList
$(document).ready(function(){
  $('.icheck').each(function(){
    var self = $(this),
      label = self.next(),
      label_text = label.text();

    label.remove();
    self.iCheck({
      checkboxClass: 'icheckbox_line-green',
      radioClass: 'iradio_line-green',
      insert: '<div class="icheck_line-icon"></div>' + label_text
    });
  });
});


//Active Nouislider Plugin For Page = AuctionList
var slider = document.getElementById('range-m');

noUiSlider.create(slider, {
	start: [12000, 68000],
 direction: 'rtl',
	connect: true,
	range: {
		'min': 0,
		'max': 100000
	},
	format: wNumb({
		decimals: 3,
		thousand: '.',
	})
});
  
var snapValues = [
	document.getElementById('valuerangelower-m'),
	document.getElementById('valuerangeupper-m')
];

slider.noUiSlider.on('update', function( values, handle ) {
	snapValues[handle].innerHTML = values[handle];
});