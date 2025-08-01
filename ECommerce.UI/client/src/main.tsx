import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import { RouterProvider } from 'react-router'
import { router } from './router/Router.tsx'
import { Provider } from 'react-redux'
import { store } from './store/store.ts'
import { CartContextProvider } from './context/CardContext.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <Provider store = {store}>
    <CartContextProvider>

    <RouterProvider router={router}></RouterProvider>
    </CartContextProvider>
    </Provider>
  </StrictMode>,
)
