

$(document).ready(function(){
  $(".owl-carousel").owlCarousel();
});

$('.owl-carousel').owlCarousel({
    loop:true,
    margin:10,
    nav:true,
    autoplay:true,
    autoplayTimeout:4000,
    autoplayHoverPause:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
})
// 

$(document).ready(function(){
  $("#flip").click(function(){
  $("#panel").slideToggle("slow");
});

});
//

const likeElements=document.querySelectorAll('#link');  
    for (const likeElement of likeElements) {
        likeElement.addEventListener('click',function(){
           
        if(this.classList.contains("content__items-checked")){
                this.classList.remove("content__items-checked") ;
    }
        else {
                this.classList.add("content__items-checked") ;
    }
    }) 
    } 


$(document).ready(function () {
    $(".price").each(function () {
        $(this).format({ format: "#,###", locale: "us" });
    });
});
 //  
 
 function changeProductList(type,element){
  // let tabs = document.getElementsByClassName('content__header-list');
  // for(i=0;i<tabs.length;i++)
  // {
  //     tabs[i]
  // }
  document.getElementById(type).style.display='block';
  switch(type ){
      case 'trend':
          
          document.getElementById('best-sell').style.display='none';
          document.getElementById('new').style.display='none';
          break;
      case 'best-sell':
          
          document.getElementById('trend').style.display='none';
          document.getElementById('new').style.display='none';
          break;
      case 'new':
          
          document.getElementById('trend').style.display='none';
          document.getElementById('best-sell').style.display='none';
          break; 

  }

}
//xóa sp
var remove_cart = document.getElementsByClassName(".btn-danger");
for (var i = 0; i < remove_cart.length; i++) {
    var button = remove_cart[i]
    button.addEventListener("click", function () {
        var button_remove = event.target
        button_remove.parentElement.parentElement.remove()
    })
}


// 
/*var modal = document.getElementById("myModal");
var btn = document.getElementById("cart");
var close = document.getElementsByClassName("close")[0];
// // tại sao lại có [0] như  thế này bởi vì mỗi close là một html colection nên khi mình muốn lấy giá trị html thì phải thêm [0]. 
// Nếu mình có 2 cái component cùng class thì khi [0] nó sẽ hiển thị component 1 còn [1] thì nó sẽ hiển thị component 2.
var close_footer = document.getElementsByClassName("close-footer")[0];
var order = document.getElementsByClassName("order")[0];
btn.onclick = function () {
  modal.style.display = "block";
}
close.onclick = function () {
  modal.style.display = "none";
}
close_footer.onclick = function () {
  modal.style.display = "none";
}
order.onclick = function () {
  alert("Cảm ơn bạn đã thanh toán đơn hàng")
}
window.onclick = function (event) {
  if (event.target == modal) {
    modal.style.display = "none";
    
  }
}


//xóa sp
var remove_cart = document.getElementsByClassName("btn-danger");
for (var i = 0; i < remove_cart.length; i++) {
  var button = remove_cart[i]
  button.addEventListener("click", function () {
    var button_remove = event.target
    button_remove.parentElement.parentElement.remove()
  })
}


// update cart 
/*function updatecart() {
    var cart_item = document.getElementsByClassName("cart-items")[0];
    var cart_rows = cart_item.getElementsByClassName("cart-row");
    var total = 0;
    for (var i = 0; i < cart_rows.length; i++) {
      var cart_row = cart_rows[i]
      var price_item = cart_row.getElementsByClassName("cart-price ")[0]
      var quantity_item = cart_row.getElementsByClassName("cart-quantity-input")[0]
      var price = parseFloat(price_item.innerText)// chuyển một chuổi string sang number để tính tổng tiền.
      var quantity = quantity_item.value // lấy giá trị trong thẻ input
      total = total + (price * quantity)
      totalA = total.toLocaleString('jp-JP')
    }
    document.getElementsByClassName("cart-total-price")[0].innerText = totalA + 'VNĐ'
    // Thay đổi text = total trong .cart-total-price. Chỉ có một .cart-total-price nên mình sử dụng [0].
  }
// thay đổi số lượng sản phẩm
var quantity_input = document.getElementsByClassName("cart-quantity-input");
for (var i = 0; i < quantity_input.length; i++) {
  var input = quantity_input[i];
  input.addEventListener("change", function (event) {
    var input = event.target
    if (isNaN(input.value) || input.value <= 0) {
      input.value = 1;
    }
    updatecart()
  })
}

// Thêm vào giỏ
var add_cart = document.getElementsByClassName("btn-cart");
for (var i = 0; i < add_cart.length; i++) {
  var add = add_cart[i];
  add.addEventListener("click", function (event) {

    var button = event.target;
    var product = button.parentElement.parentElement;
    var img = product.parentElement.getElementsByClassName("box-pro-img")[0].src
    var title = product.getElementsByClassName("content__product")[0].innerText
    var price = product.getElementsByClassName("price")[0].innerText
    addItemToCart(title, price, img)
    // Khi thêm sản phẩm vào giỏ hàng thì sẽ hiển thị modal
    modal.style.display = "block";
    
    updatecart()
  })
}
function addItemToCart(title, price, img) {
    var cartRow = document.createElement('div')
    cartRow.classList.add('cart-row')
    var cartItems = document.getElementsByClassName('cart-items')[0]
    var cart_title = cartItems.getElementsByClassName('cart-item-title')
    //Nếu title của sản phẩm bằng với title mà bạn thêm vao giỏ hàng thì sẽ thông cho user.
    for (var i = 0; i < cart_title.length; i++) {
      if (cart_title[i].innerText == title) {
        alert('Sản Phẩm Đã Có Trong Giỏ Hàng')
        return
      }
    }
  
    var cartRowContents = `
    <div class="cart-item cart-column">
        <img class="cart-item-image" src="${img}" width="100" height="100">
        <span class="cart-item-title">${title}</span>
    </div>
    <span class="cart-price cart-column">${price}</span>
    <div class="cart-quantity cart-column">
        <input class="cart-quantity-input" type="number" value="1">
        <button class="btn btn-danger" type="button">Xóa</button>
    </div>`
    cartRow.innerHTML = cartRowContents
    cartItems.append(cartRow)
    cartRow.getElementsByClassName('btn-danger')[0].addEventListener('click', function () {
      var button_remove = event.target
      button_remove.parentElement.parentElement.remove()
      updatecart()
    })
    cartRow.getElementsByClassName('cart-quantity-input')[0].addEventListener('change', function (event) {
      var input = event.target
      if (isNaN(input.value) || input.value <= 0) {
        input.value = 1;
      }
      updatecart()
    })
  }*/