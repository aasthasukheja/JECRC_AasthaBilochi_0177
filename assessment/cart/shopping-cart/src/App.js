import React, { useState } from "react";
import ProductList from "./Components/ProductList";
import Cart from "./Components/Cart";

const PRODUCTS = [
  { id: 1, name: "React T-Shirt", price: 25 },
  { id: 2, name: "Node Hoodie", price: 40 },
  { id: 3, name: "JS Cap", price: 15 }
];

function App() {
  const [cart, setCart] = useState([]);

  // ADD TO CART
  const addToCart = (product) => {
    const existing = cart.find(item => item.id === product.id);

    if (existing) {
      setCart(cart.map(item =>
        item.id === product.id
          ? { ...item, qty: item.qty + 1 }
          : item
      ));
    } else {
      setCart([...cart, { ...product, qty: 1 }]);
    }
  };

  // UPDATE QUANTITY
  const updateQty = (id, qty) => {
    if (qty <= 0) {
      removeItem(id);
      return;
    }

    setCart(cart.map(item =>
      item.id === id ? { ...item, qty } : item
    ));
  };

  // REMOVE ITEM
  const removeItem = (id) => {
    setCart(cart.filter(item => item.id !== id));
  };

  // TOTAL PRICE (Derived State)
  const total = cart.reduce((sum, item) => {
    return sum + item.price * item.qty;
  }, 0);

  return (
    <div style={{ padding: "20px" }}>
      <h1>🛒 Mini Shopping Cart</h1>

      <ProductList products={PRODUCTS} addToCart={addToCart} />

      <hr />

      <Cart
        cart={cart}
        updateQty={updateQty}
        removeItem={removeItem}
        total={total}
      />
    </div>
  );
}

export default App;