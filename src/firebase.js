import firebase from "firebase";

const firebaseApp = firebase.initializeApp({
  apiKey: "",
  authDomain: "instagramclone-17e85.firebaseapp.com",
  databaseURL: "https://instagramclone-17e85.firebaseio.com",
  projectId: "instagramclone-17e85",
  storageBucket: "instagramclone-17e85.appspot.com",
  messagingSenderId: "913947098693",
  appId: "1:913947098693:web:6b6b2e9315cefc41982d2c",
  measurementId: "G-MTFDP3Y90K"
});
const db = firebaseApp.firestore();
const auth = firebase.auth();
const storage = firebase.storage();

export { db, auth, storage };
