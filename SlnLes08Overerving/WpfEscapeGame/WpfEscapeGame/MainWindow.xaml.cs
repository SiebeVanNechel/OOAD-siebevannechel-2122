﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfEscapeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        Room currentRoom;
        public MainWindow()
        {
            InitializeComponent();
            // define room
            Room room1 = new Room(
               "bedroom",
               "I seem to be in a medium sized bedroom. There is a locker to the left, a nice rug on the floor, and a bed to the right. ", "ss-bedroom.png");
           
            // define items
            Item key1 = new Item("small silver key", "A small silver key, makes me think of one I had at highschool. ");
            Item key2 = new Item("large key", "A large key. Could this be my way out? ");
            Item locker = new Item("locker", "A locker. I wonder what's inside. ", false);
            locker.HiddenItem = key2;
            locker.IsLocked = true;
            locker.Key = key1;
            Item bed = new Item("bed", "Just a bed. I am not tired right now. ", false);
            bed.HiddenItem = key1;

            Item chair = new Item("chair", "Just a chair",false);
            Item poster = new Item("poster", "Just a poster");
            // setup bedroom
            room1.Items.Add(new Item("floor mat", "A bit ragged floor mat, but still one of the  most popular designs. "));
            room1.Items.Add(bed);
            room1.Items.Add(locker);

            // start game
            currentRoom = room1;
            lblMessage.Content = "I am awake, but cannot remember who I am!? Must have been a hell of aparty last night... ";


            //add stoel & poster
            room1.Items.Add(chair);
            room1.Items.Add(poster);


            //computer room & living
            Room living = new Room(
              "living",
              "I seem to be in a small living. There are two doors, a big clock on the wall, and a closet to the right. ", "ss-living.png");
            Item clock = new Item("clock", "This clock is broken", false);
            Item closet = new Item("closet", "This is a old brown closet", false);
            living.Items.Add(clock);
            living.Items.Add(closet);

            Room computerRoom = new Room(
               "computer room",
               "I seem to be in a big computer room. There is one door, a beautiful painting on the wall, and two chairs to the right. ", "ss-computer.png");
            Item computer = new Item("computer", "Can't login to the computer", false);
            Item painting = new Item("painting", "This is an old painting from 100 years ago", false);
            computerRoom.Items.Add(computer);
            computerRoom.Items.Add(painting);

            //Add doors
            Door bedroomdoor = new Door("Bedroomdoor", "Go through this door if u want to go to the living room", living);
            bedroomdoor.IsLocked = true;
            bedroomdoor.Key = key2;
            room1.Doors.Add(bedroomdoor);
            Door leftdoorLiving = new Door("Left door in living", "Go through this door if u want to go to the computer room", computerRoom);
            living.Doors.Add(leftdoorLiving);
            Door computerroomdoor = new Door("Door computer room", "Go through this door if u want to go to the living room", living);
            computerRoom.Doors.Add(computerroomdoor);
            Door otherlivingdoor = new Door("Other living door", "This door goas to nothing", null);
            otherlivingdoor.IsLocked = true;
            living.Doors.Add(otherlivingdoor);

            UpdateUI();
        }
        /// <summary>
        /// Update de items in de ListBoxes
        /// </summary>
        private void UpdateUI()
        {
            lstRoomItems.Items.Clear();
            foreach (Item itm in currentRoom.Items)
            {
                lstRoomItems.Items.Add(itm);
            }
            lstRoomDoors.Items.Clear();
            foreach(Door deur in currentRoom.Doors)
            {
                lstRoomDoors.Items.Add(deur);
            }
            txtRoomDesc.Text = currentRoom.Description;
            imgBox.Source = new BitmapImage(new Uri($"Image/{currentRoom.Image}", UriKind.Relative));

        }
        private void LstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCheck.IsEnabled = lstRoomItems.SelectedValue != null; // room item selected
            btnPickUp.IsEnabled = lstRoomItems.SelectedValue != null; // room item selected
            btnUseOn.IsEnabled = lstRoomItems.SelectedValue != null && lstMyItems.SelectedValue != null; // room item and picked up item selected

            btnDrop.IsEnabled = lstMyItems.SelectedValue != null;
            btnEnter.IsEnabled = lstRoomDoors.SelectedValue != null;
            btnOpenWith.IsEnabled = lstRoomDoors.SelectedValue != null;
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            // 1. find item to check
            Item roomItem = (Item)lstRoomItems.SelectedItem;
            // 2. is it locked?
            if (roomItem.IsLocked)
            {
                lblMessage.Content = $"{roomItem.Description}It is firmly locked. ";
                return;
            }
            // 3. does it contain a hidden item?
            Item foundItem = roomItem.HiddenItem;
            if (foundItem != null)
            {
                lblMessage.Content = $"Oh, look, I found a {foundItem.Name}";
                lstMyItems.Items.Add(foundItem);
                roomItem.HiddenItem = null;
                return;
            }
            // 4. just another item; show description
            lblMessage.Content = roomItem.Description;
        }

        private void BtnUseOn_Click(object sender, RoutedEventArgs e)
        {
            // 1. find both items
            Item myItem = (Item)lstMyItems.SelectedItem;
            Item roomItem = (Item)lstRoomItems.SelectedItem;

            // 2. item doesn't fit
            if (roomItem.Key != myItem)
            {
                lblMessage.Content = "That doesn't seem to work. ";
                return;
            }

            // 3. item fits; other item unlocked
            roomItem.IsLocked = false;
            roomItem.Key = null;
            lstMyItems.Items.Remove(myItem);
            lblMessage.Content = $"I just unlocked the {roomItem.Name}!";
        }

        private void BtnPickUp_Click(object sender, RoutedEventArgs e)
        {
            // 1. find selected item
            Item selItem = (Item)lstRoomItems.SelectedItem;

            // 2. add item to your items list
            if (selItem.IsPortable==false)
            {
                lblMessage.Content = $"{selItem.Name} is not portable. ";
            }
            else
            {
                lblMessage.Content = $"I just picked up the {selItem.Name}. ";
                lstMyItems.Items.Add(selItem);
                lstRoomItems.Items.Remove(selItem);
                currentRoom.Items.Remove(selItem);
            }
        }

        private void btnDrop_Click(object sender, RoutedEventArgs e)
        {
            Item myItem = (Item)lstMyItems.SelectedItem;

            lstMyItems.Items.Remove(myItem);
            lstRoomItems.Items.Add(myItem);
            currentRoom.Items.Add(myItem);

        }

        private void btnOpenWith_Click(object sender, RoutedEventArgs e)
        {
            Item myItem = (Item)lstMyItems.SelectedItem;
            Door myDoor = (Door)lstRoomDoors.SelectedItem;

            if (myDoor.Key != myItem)
            {
                lblMessage.Content = "That doesn't seem to work. ";
                return;
            }

            myDoor.IsLocked = false;
            myDoor.Key = null;
            lstMyItems.Items.Remove(myItem);

            currentRoom = myDoor.NextRoom;
            lblMessage.Content = $"Ohh, I'm in a new room now!";
            UpdateUI();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Door myDoor = (Door)lstRoomDoors.SelectedItem;

            if (myDoor.IsLocked)
            {
                lblMessage.Content = $"{myDoor} is firmly locked. ";
                return;
            }
            currentRoom = myDoor.NextRoom;
            UpdateUI();
        }
    }
}

