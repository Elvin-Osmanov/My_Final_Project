
$(document).ready(function () {
  
  $(".bookinglink").click(function(e){
    e.preventDefault()
    $("#modal").fadeIn()
    
})

$(".close-icon").click(function(e){
    e.preventDefault()
    $("#modal").fadeOut()
})


$("html , body").keydown(function(x){
    if(x.which==27){
        $("#modal").fadeOut()
    }
})

window.addEventListener("click",function(e){
  if($(e.target).hasClass("modal")){

    $('#modal').fadeOut();
  }
})
  

$(window).scroll(function(){
  if($("html").scrollTop()>=100){
    $('.prenavbar').addClass('scrolled');
    
  }
  else{
    $('.prenavbar').removeClass('scrolled');
   
  }
})
$('.carousel').slick({
  infinite: true,
  slidesToShow: 3,
  slidesToScroll: 3,
  dots:true
 
});


$('#store .slider').slick({
  infinite: true,
  slidesToShow: 2,
  slidesToScroll: 2

});

$('.play-btn').magnificPopup({
   disableOn: 700,
		type: 'iframe',
		mainClass: 'mfp-fade',
		removalDelay: 160,
		preloader: false,
		fixedContentPos: true
});




$(".back").click(function(e) {
  e.preventDefault();
  $("html").animate({
      scrollTop: 0
  }, 1000);
});


$(".menu-tabs .tabs li").each(function(e){

  $(this).click(function(e){
    e.preventDefault();
    console.log("kk")

    $('.menu-tabs .tabs li.active').removeClass("active")
    $(this).addClass("active")

   


    

    var href = $(this).attr('href')
    
    $(".menus ul.show").removeClass("show")
    $(href).addClass("show")

    if($(".menus ul#main").hasClass('show')){
      $("#specialities").css('background-image','url(./assets/images/specialitites/maindish.jpg)')
    }else if($(".menus ul#starter").hasClass('show')){
      $("#specialities").css('background-image','url(./assets/images/specialitites/starter.jpg)')
    }else if($(".menus ul#dessert").hasClass('show')){
      $("#specialities").css('background-image','url(./assets/images/specialitites/dessert.jpg)')
    }else if($(".menus ul#sea").hasClass('show')){
      $("#specialities").css('background-image','url(./assets/images/specialitites/seafood.jpg)')
    }else{
      $("#specialities").css('background-image','url(./assets/images/specialitites/drinks.jpg)')
    }
    
   

    
   

   

    




  })

})

$(window).scroll(function () {
  var hT = $("#stats").offset().top,
    hH = $("#stats").outerHeight(),
    wH = $(window).height(),
    wS = $(this).scrollTop();
  if (wS > (hT+hH-wH) && (hT > wS) && (wS+wH > hT+hH)) {
    let odometers = document.querySelectorAll(".odometer");

    let speed = 300;

    odometers.forEach((counter) => {
      let updateCount = () => {
        let target = +counter.getAttribute("data-target");
        let count = +counter.innerText;

        let inc = Math.ceil(target / speed);

        if (count < target) {
          counter.innerText = count + inc;
          setTimeout(updateCount, 10);
        } else {
          count.innerText = target;
        }
      };

      updateCount();
    });
  }

  
});

});

// let map;

// function initMap() {
//   map = new google.maps.Map(document.getElementById("contact-intro"), {
//     center: { lat: -34.397, lng: 150.644 },
//     zoom: 8,
//     styles: [
//       { elementType: "geometry", stylers: [{ color: "#242f3e" }] },
//       { elementType: "labels.text.stroke", stylers: [{ color: "#242f3e" }] },
//       { elementType: "labels.text.fill", stylers: [{ color: "#746855" }] },
//       {
//         featureType: "administrative.locality",
//         elementType: "labels.text.fill",
//         stylers: [{ color: "#d59563" }],
//       },
//       {
//         featureType: "poi",
//         elementType: "labels.text.fill",
//         stylers: [{ color: "#d59563" }],
//       },
//       {
//         featureType: "poi.park",
//         elementType: "geometry",
//         stylers: [{ color: "#263c3f" }],
//       },
//       {
//         featureType: "poi.park",
//         elementType: "labels.text.fill",
//         stylers: [{ color: "#6b9a76" }],
//       },
//       {
//         featureType: "road",
//         elementType: "geometry",
//         stylers: [{ color: "#38414e" }],
//       },
//       {
//         featureType: "road",
//         elementType: "geometry.stroke",
//         stylers: [{ color: "#212a37" }],
//       },
//       {
//         featureType: "road",
//         elementType: "labels.text.fill",
//         stylers: [{ color: "#9ca5b3" }],
//       },
//       {
//         featureType: "road.highway",
//         elementType: "geometry",
//         stylers: [{ color: "#746855" }],
//       },
//       {
//         featureType: "road.highway",
//         elementType: "geometry.stroke",
//         stylers: [{ color: "#1f2835" }],
//       },
//       {
//         featureType: "road.highway",
//         elementType: "labels.text.fill",
//         stylers: [{ color: "#f3d19c" }],
//       },
//       {
//         featureType: "transit",
//         elementType: "geometry",
//         stylers: [{ color: "#2f3948" }],
//       },
//       {
//         featureType: "transit.station",
//         elementType: "labels.text.fill",
//         stylers: [{ color: "#d59563" }],
//       },
//       {
//         featureType: "water",
//         elementType: "geometry",
//         stylers: [{ color: "#17263c" }],
//       },
//       {
//         featureType: "water",
//         elementType: "labels.text.fill",
//         stylers: [{ color: "#515c6d" }],
//       },
//       {
//         featureType: "water",
//         elementType: "labels.text.stroke",
//         stylers: [{ color: "#17263c" }],
//       },
//     ]
//   });
// }