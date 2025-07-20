import { ShoppingCart } from "@mui/icons-material";
import { AppBar, Badge, Box, Button,  IconButton,  Stack, Toolbar, Typography } from "@mui/material";
import { NavLink } from "react-router";
const links = [
  {title:"Home",to:"/"},
  {title:"Catalog",to:"/catalog"},
  {title:"About",to:"/about"},
  {title:"Contact",to:"/contact"},
]


const style = {
  color:"inherit",
  textDecoration:"none",
  "&:hover":{
    color:"text.primary"
  },
  "&.active":{
   color:"text.primary" 
  }
}
export default function Header() {



  return <>
  <AppBar position="static" sx={{mb:4}} >
    <Toolbar sx={{ display:"flex", justifyContent:"space-between"}}>
      <Box sx={{display:"flex", alignItems:"center"}}>

      <Typography variant="h6">E Commerce</Typography>
      <Stack direction="row">
        {
        links.map(link => 
        <Button key={link.to} component={NavLink}
        to={link.to}
        sx={style} >
          {link.title}
        </Button>)
        
        }

      </Stack>
    </Box>

<Box >
<IconButton size="large" edge="start" color="inherit">
<Badge badgeContent="2" color="secondary">
  <ShoppingCart></ShoppingCart>
</Badge>
</IconButton>
</Box>

    </Toolbar>
  </AppBar>
  </>

  
}