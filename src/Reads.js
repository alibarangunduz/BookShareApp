import React from 'react';
import Typography from '@material-ui/core/Typography';
import Box from '@material-ui/core/Box';
import Button from '@material-ui/core/Button';
import Popover from '@material-ui/core/Popover';
import PopupState, { bindTrigger, bindPopover } from 'material-ui-popup-state';

export default function Reads(props) {
  return (
    <PopupState variant="popover" popupId="demo-popup-popover">
      {(popupState) => (
        <div>
          <Button variant="contained" color="primary" {...bindTrigger(popupState)}>
          {props.readPosts.length > 0 ? props.readPosts.length: 0}
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
              { props.readPosts.length > 0 ?
                  props.readPosts.map((read, index) => {
                  return <li key={index}>{read.name}</li>
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
