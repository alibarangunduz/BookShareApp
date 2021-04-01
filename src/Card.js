import React, {  } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardHeader from '@material-ui/core/CardHeader';
import CardContent from '@material-ui/core/CardContent';
import CardActions from '@material-ui/core/CardActions';
import Avatar from '@material-ui/core/Avatar';
import IconButton from '@material-ui/core/IconButton';
import Typography from '@material-ui/core/Typography';
import { red } from '@material-ui/core/colors';
import FavoriteIcon from '@material-ui/icons/Favorite';
import FavoriteBorderIcon from '@material-ui/icons/FavoriteBorder';
import Likes from './Likes';
import CheckIcon from '@material-ui/icons/Check';
import './Card.css'
import axios from 'axios';
import { Button } from '@material-ui/core';
import Reads from './Reads';

const api = axios.create({
    baseURL: `http://localhost:52851/api`
  });
  


const useStyles = makeStyles((theme) => ({
  root: {
    maxWidth: 345,
  },
  media: {
    height: 0,
    paddingTop: '56.25%', // 16:9
  },
  expand: {
    transform: 'rotate(0deg)',
    marginLeft: 'auto',
    transition: theme.transitions.create('transform', {
      duration: theme.transitions.duration.shortest,
    }),
  },
  expandOpen: {
    transform: 'rotate(180deg)',
  },
  avatar: {
    backgroundColor: red[500],
  },
}));


  

export default function RecipeReviewCard(props) {
  
  const classes = useStyles();
  
 


 
  
  const handleLike = (e) => {
    e.preventDefault();
    
    api.post(`/Post/LikePost`, {PostID: props.postID, UserID: props.userUserID, Name: props.username}).then(res => {
        
        if(res.data.isSuccess) {
          
          props.isLiked();

        }else {

          props.isLiked();
        }
      });
      
  }
  const handleRead = (e) => {
    e.preventDefault();
    
    api.post(`/Post/ReadPost`, {PostID: props.postID, UserID: props.userUserID, Name: props.username}).then(res => {
        
        if(res.data.isSuccess) {
          
          props.isLiked();

        }else {

          props.isLiked();
        }
      });
      
  }

  return (
    <div className="Card">
    <Card className={classes.root}>
      <CardHeader
        avatar={
          <Avatar aria-label="recipe" className={classes.avatar}>
            {props.name[0]}
          </Avatar>
        }
      
        title={props.name}
        subheader={props.postedDate}
      />
      <p className="Card__Header">{props.postHeader}</p>
      <CardContent>
        <Typography variant="body2" color="textSecondary" component="p">
         {props.postContent}
        </Typography>
      </CardContent>
      <CardActions disableSpacing>
      <Likes 
          postLikes={props.postLikes}
      />
        {props.userUserID ? 
            <IconButton onClick={handleLike} aria-label="add to favorites">
          {props.postLikes.filter(function(like){ return like.userID === props.userUserID }).length > 0 ? <FavoriteIcon /> : <FavoriteBorderIcon/> }
          
        </IconButton>: " "}
        {props.userUserID ? 
        
          <Button onClick={handleRead}>{props.readPosts.filter(function(read){ return read.userID === props.userUserID }).length > 0 ? <CheckIcon>okundu</CheckIcon> : <p>okunmadı</p>}</Button>
          : " "
        } 
        <Reads 
          readPosts={props?.readPosts}
        />
      </CardActions>
    </Card>
  
    
    </div>
  );
}
