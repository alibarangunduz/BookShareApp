import React, { useEffect, useState } from 'react';
import './App.css';
import { Button, Input, makeStyles, Modal } from '@material-ui/core';
import ImportContactsIcon from '@material-ui/icons/ImportContacts';
import Card from './Card';
import axios from 'axios';


const api = axios.create({
  baseURL: `http://localhost:52851/api`
});





function getModalStyle() {
  const top = 50
  const left = 50

  return {
    top: `${top}%`,
    left: `${left}%`,
    transform: `translate(-${top}%, -${left}%)`,
  };
}

const useStyles = makeStyles((theme) => ({
  paper: {
    position: "absolute",
    width: 400,
    backgroundColor: theme.palette.background.paper,
    border: "2px solid #000",
    boxShadow: theme.shadows[5],
    padding: theme.spacing(2, 4, 3),
  },
}));



function App() {


  const classes = useStyles();

  const [modalStyle] = useState(getModalStyle);

  const [posts, setPosts] = useState([]);
  const [likedPosts, setLikedPosts] = useState([]);
  const [ReadPosts, setReadPosts] = useState([]);
  const [open, setOpen] = useState(false);
  const [openSignIn, setOpenSignIn] = useState(false);
  const [openBook, setOpenBook] = useState(false);
  const [name, setName] = useState('');
  const [password, setPassword] = useState('');
  const [email, setEmail] = useState('');
  const [user, setUser] = useState(false);
  const [BookHeader, setBookHeader] = useState('');
  const [BookContent, setBookContent] = useState('');
  const [realTime, setRealTime] = useState(false);
  const [isChangedPosts, setIsChangedPosts] = useState(false);


  useEffect(() => {
    api.get(`/Post`).then(res => {
      setPosts(res.data);

    });
  }, []);

  useEffect(() => {
    api.get(`/Post`).then(res => {
      setPosts(res.data);

    });
  }, [realTime]);

  useEffect(() => {

  }, [posts]);

  
  const signUp = (event) => {
    event.preventDefault();
    

    api.post(`/Auth/CreateUser`, { userName: email, name: name, password: password }).then(res => {

      if (res.data.isSuccess) {
        setUser(res.data);
        setOpen(false);

      } else {
        alert("Email already exsit !! ")
      }
    });

    setOpen(false);
  }

  const signIn = (event) => {
    event.preventDefault();

    api.post(`/Auth/LoginUser`, { userName: email, password: password }).then(res => {


      if (res.data.isSuccess) {
        setUser(res.data)


      } else {
        alert("Email or Password incorrect !!");
      }

    });

    setOpenSignIn(false);
  }
  const createBook = (event) => {
    event.preventDefault();
    api.post(`/Post/CreatePost`, { UserID: user.userID, PostHeader: BookHeader, PostContent: BookContent, Name: user.name }).then(res => {

      if (res.data.isSuccess) {
        alert("successfully created")
        setOpenBook(false);
        setRealTime(!realTime);
      } else {
        alert("something went wrong !! ")
      }
    });
    setOpenBook(false);
  }
  const isLiked = () => {

    setRealTime(!realTime);
  }

  const myLikes = (event) => {
    event.preventDefault();
    var i = 0;
    var j = 0;
    var k = 0;
    for (i; i < posts.length; i++) {
      for (j = 0; j < posts[i].postLikes.length; j++) {
        if (posts[i].postLikes[j].userID === user.userID) {
          likedPosts[k] = posts[i];
          k++
        }
      }
    }
    setPosts(likedPosts);

  }
  const myReads = (event) => {
    event.preventDefault();
    var i = 0;
    var j = 0;
    var k = 0;
    for (i; i < posts.length; i++) {
      for (j = 0; j < posts[i].readPosts.length; j++) {
        if (posts[i].readPosts[j].userID === user.userID) {
          ReadPosts[k] = posts[i];
          k++
        }
      }
    }
    setPosts(ReadPosts);

  }
  const returnMainPage = (event) => {
    setRealTime(!realTime);
  }

  const sortByPriceAsc = () => {
    setPosts(posts.sort((a, b) => a.postHeader.localeCompare(b.postHeader)));
    setIsChangedPosts(!isChangedPosts);
  }

  const sortByDate = () => {
    setPosts(posts.reverse());
    console.log(posts);
    setIsChangedPosts(!isChangedPosts);
  }

  const mostLiked = () => {
    setPosts(posts.sort((a, b) => b.postLikes.length - a.postLikes.length));
    setIsChangedPosts(!isChangedPosts);
  }
  return (
    <div className="app">

      <Modal open={open} onClose={() => setOpen(false)}>
        <div style={modalStyle} className={classes.paper}>
          <form className="app__signup">
            <center>

            </center>
            <Input
              type="text"
              placeholder="username"
              value={name}
              onChange={(e) => setName(e.target.value)}
            />
            <Input
              type="text"
              placeholder="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
            <Input
              type="password"
              placeholder="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />

            <Button type="submit" onClick={signUp}>
              Sign Up
            </Button>
          </form>
        </div>
      </Modal>
      <Modal open={openSignIn} onClose={() => setOpenSignIn(false)}>
        <div style={modalStyle} className={classes.paper}>
          <form className="app__signup">
            <center>

            </center>
            <Input
              type="text"
              placeholder="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
            />
            <Input
              type="password"
              placeholder="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />

            <Button type="submit" onClick={signIn}>
              Sign In
            </Button>
          </form>
        </div>
      </Modal>
      <Modal open={openBook} onClose={() => setOpenBook(false)}>
        <div style={modalStyle} className={classes.paper}>
          <form className="app__signup">
            <center>

            </center>
            <Input
              type="text"
              placeholder="BookHeader"
              value={BookHeader}
              onChange={(e) => setBookHeader(e.target.value)}
            />
            <Input
              type="text"
              placeholder="BookContent"
              value={BookContent}
              onChange={(e) => setBookContent(e.target.value)}
            />

            <Button type="submit" onClick={createBook}>
              CreateBook
            </Button>
          </form>
        </div>
      </Modal>

      <div className="app__header">
        <ImportContactsIcon />
        

        {user ? (

          <>
          <Button variant="contained" onClick={returnMainPage}>Anasayfa</Button>
            <h5>Filtrele</h5>
            <Button variant="contained" onClick={myLikes}>Begendiklerim</Button>
            <Button variant="contained" onClick={myReads}>Okuduklarım</Button>
            <h5>Sırala</h5>
            <Button variant="contained" onClick={sortByPriceAsc}>Alfabetik</Button>
            <Button variant="contained" onClick={sortByDate}>Eklenme Tarihi son</Button>
            <Button variant="contained" onClick={mostLiked}>En Çok Beğenilen</Button>            
            <strong>Welcome {user.name} </strong>
            <Button onClick={() => window.location.reload(false)}>Logout</Button>
          </>

        ) : (
            <div className="app__loginContainer">
              <Button onClick={() => setOpenSignIn(true)}>Sign In</Button>
              <Button onClick={() => setOpen(true)}>Sign Up</Button>
            </div>
          )
        }
      </div>

      {user ? (
        <div>
          <Button className="app__createPost" variant="contained" onClick={() => setOpenBook(true)}>CreateBook</Button>

        </div>
      ) : (
          <h3>Sorry you need to login </h3>
        )}

      <div className="app__posts">
        <div className="app_postsLeft" style={{}}>

          {user.userID ?
            posts?.map((post, index) => (
              <Card
                key={index}
                postID={post.postID}
                userID={post.userID}
                postHeader={post.postHeader}
                postContent={post.postContent}
                name={post.name}
                postedDate={post.postedDate}
                postLikes={post.postLikes}
                readPosts={post.readPosts}
                username={user.name}
                userUserID={user.userID}
                isLiked={isLiked}
              />
            )) : " "

          }



        </div>
      </div>
      {isChangedPosts ? '' : ''}

    </div>
  );
}

export default App;
