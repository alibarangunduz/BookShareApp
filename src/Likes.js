import React from 'react';
import Typography from '@material-ui/core/Typography';
import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import Popover from '@material-ui/core/Popover';
import PopupState, { bindTrigger, bindPopover } from 'material-ui-popup-state';

export default function Likes(props) {
  return (
    <PopupState variant="popover" popupId="demo-popup-popover">
      {(popupState) => (
        <div>
          <Button variant="contained" color="secondary" {...bindTrigger(popupState)}>
          {props.postLikes.length > 0 ? props.postLikes.length: 0}
          </Button>
          <Popover
            {...bindPopover(popupState)}

            anchorOrigin={{
              vertical: 'bottom',
              horizontal: 'center',
            }}
            transformOrigin={{
              vertical: 'top',
              horizontal: 'center',
            }}
          >
            <Box p={2}>
              <Typography> 
              { props.postLikes.length > 0 ?
                  props.postLikes.map((like, index) => {
                  return <li key={index}>{like.name}</li>
                  }): " "
              }
            </Typography>
            </Box>
          </Popover>
        </div>
      )}
    </PopupState>
  );
}
