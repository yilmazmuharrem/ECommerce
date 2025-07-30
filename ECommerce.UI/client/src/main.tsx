import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import { RouterProvider } from 'react-router'
import { router } from './router/Router.tsx'
import { CartContextProvider } from './context/CardContext.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <CartContextProvider>

    <RouterProvider router={router}></RouterProvider>
    </CartContextProvider>
  </StrictMode>,
)
