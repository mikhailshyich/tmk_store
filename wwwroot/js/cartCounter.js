function counter() {
    const cart = document.querySelector('.card-item');
    updateCartItemCount();
    function updateCartItemCount() {
        cart.addEventListener('click', (event) => {
            let currenItems, minusBtn;
            if (event.target.matches('.counter-minus') || event.target.matches('.counter-plus')) {
                const counter = event.target.closest('.counter');
                // console.log('counter ', counter);
                currenItems = counter.querySelector('.counter-text');
                // console.log('currenItems ', currenItems);
                minusBtn = counter.querySelector('.counter-minus');
            }

            if (event.target.matches('.counter-plus')) {
                currenItems.value = ++currenItems.value;
                minusBtn.removeAttribute('disabled');
            }
            if (event.target.matches('.counter-minus')) {
                if (parseInt(currenItems.value) > 2) {
                    currenItems.value = --currenItems.value;
                    minusBtn.removeAttribute('disabled');
                }
                else {
                    currenItems.value = --currenItems.value;
                    minusBtn.setAttribute('disabled', true);
                }
            }
        });
        cart.addEventListener('input', (event) => {
            const counter = event.target.closest('.counter');
            // console.log('counter ', counter);
            currenItems = counter.querySelector('.counter-text');
            // console.log('currenItems ', currenItems);
            plusBtn = counter.querySelector('.counter-plus');

            if (parseInt(currenItems.value) <= 0) {
                currenItems.value = 1;
            }
            else if (parseInt(currenItems.value) > 9999) {
                currenItems.value = 9999;
                plusBtn.setAttribute('disabled', true);
            }
        });
    }

}