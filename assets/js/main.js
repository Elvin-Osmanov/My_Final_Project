
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

});