// Sports Tactics Board
//
// http://sportstacticsbd.sourceforge.net/
// http://sourceforge.net/projects/sportstacticsbd/
// 
// Sports Tactics Board is a utility that allows coaches, trainers and 
// officials to describe sports tactics, strategies and positioning using 
// a magnetic or chalk-board style approach.
// 
// Copyright (C) 2007 Robert Turner
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SportsTacticsBoard
{
  class SavedLayoutManager
  {
    /// <summary>
    /// Stores the saved layouts.
    /// </summary>
    private List<SavedLayout> savedLayouts;

    /// <summary>
    /// Default constructor for the saved layout manager.
    /// </summary>
    public SavedLayoutManager() {
      savedLayouts = new List<SavedLayout>();
      ReloadLayouts();
    }

    /// <summary>
    /// Loads the layouts from disk into local data members.
    /// </summary>
    public void ReloadLayouts()
    {
      // TODO: Load the layouts from disk.
      savedLayouts = new List<SavedLayout>();
    }

    /// <summary>
    /// Updates the specified menu by inserting menu items for each of 
    /// the saved layouts into the menu. The items are inserted into 
    /// sub-menus corresponding to the categories. Only saved layouts 
    /// for the specified field type will be inserted.
    /// </summary>
    /// <param name="menuToInsertInto">The menu item that will have a drop 
    /// down menu created beneath it with the layouts in.</param>
    /// <param name="fieldTypeTag">Only layouts for the this field type 
    /// will be inserted into the menu.</param>
    /// <param name="menuItemClickEventHandler">The event handler to invoke 
    /// when any of the inserted menu items are clicked.</param>
    /// <returns>true if items were inserted into the menu, false otherwise</returns>
    public bool UpdateMenu(ToolStripMenuItem menuToInsertInto, string fieldTypeTag, EventHandler menuItemClickEventHandler) {
      Dictionary<string, ToolStripMenuItem> categorySubMenus = new Dictionary<string, ToolStripMenuItem>();
      menuToInsertInto.DropDownItems.Clear();
      bool itemsInserted = false;
      if (savedLayouts.Count > 0) {
        foreach (SavedLayout savedLayout in savedLayouts) {
          if (MatchesFieldTypeTag(fieldTypeTag, savedLayout.FieldTypeTag)) {
            ToolStripMenuItem menuToInsertIn = menuToInsertInto;
            if (!string.IsNullOrEmpty(savedLayout.Category)) {
              if (categorySubMenus.ContainsKey(savedLayout.Category)) {
                menuToInsertIn = categorySubMenus[savedLayout.Category];
              } else {
                menuToInsertIn = new ToolStripMenuItem(savedLayout.Category);
                categorySubMenus.Add(savedLayout.Category, menuToInsertIn);
              }
            }
            ToolStripMenuItem mi = new ToolStripMenuItem(savedLayout.Name, null, menuItemClickEventHandler);
            if (savedLayout.Description.Length > 0) {
              mi.ToolTipText = savedLayout.Description;
            }
            menuToInsertIn.DropDownItems.Add(mi);
            itemsInserted = true;
          }
        }
      }
      if (categorySubMenus.Count > 0) {
        int index = 0;
        foreach (ToolStripMenuItem menuItem in categorySubMenus.Values) {
          menuToInsertInto.DropDownItems.Insert(index, menuItem);
          index++;
        }
      }
      if (!itemsInserted) {
        string menuItemStr = Properties.Resources.ResourceManager.GetString("NoSavedLayoutsMenuItemText");
        ToolStripMenuItem mi = new ToolStripMenuItem(menuItemStr);
        mi.Enabled = false;
        menuToInsertInto.DropDownItems.Add(mi);
      }
      return itemsInserted;
    }

    /// <summary>
    /// Retrieves the field object layout for the specified menu item. This 
    /// menu item must have been inserted by UpdateMenu().
    /// </summary>
    /// <param name="menuItem">The menu item to obtain the layout for.</param>
    /// <param name="fieldTypeTag">The field type that the layout must apply to.</param>
    /// <returns>The field object layout for the menu item. Returns null if no layout is 
    /// found or does not apply for the supplied field type.</returns>
    public Layout GetLayoutForMenuItem(ToolStripMenuItem menuItem, string fieldTypeTag) {
      string name = menuItem.Text;
      foreach (SavedLayout savedLayout in savedLayouts) {
        if ((MatchesFieldTypeTag(fieldTypeTag, savedLayout.FieldTypeTag)) &&
            (savedLayout.Name == name)) {
          return savedLayout.Layout;
        }
      }
      return null;
    }

    /// <summary>
    /// Prompts the user to save the current layout, along with asking for 
    /// details under which to save the layout. If the user saves the layout, it
    /// is added to the list of saved layouts.
    /// </summary>
    /// <param name="layoutToSave">The layout to be saved which describes the 
    /// current positions of the field objects.</param>
    /// <param name="fieldTypeTag">Identifies the field type of the layout.</param>
    public void SaveCurrentLayout(Layout layoutToSave, string fieldTypeTag) {
      SavedLayout sl =
        SavedLayoutInformation.AskUserForSavedLayoutDetails(layoutToSave,
                                                            fieldTypeTag,
                                                            GetCurrentSavedLayoutCategories(fieldTypeTag));
      if (null != sl) {
        // TODO: Save the layout to disk
        savedLayouts.Add(sl);
      }
    }

    /// <summary>
    /// Helper method to compare two field type tags and account for 
    /// null or empty string objects.
    /// </summary>
    /// <param name="fieldTypeTag">The first field type tag to compare.</param>
    /// <param name="layoutFieldTypeTag">The second field type tag to compare.</param>
    /// <returns>true if the field type tags are the same, false otherwise</returns>
    private static bool MatchesFieldTypeTag(string fieldTypeTag, string layoutFieldTypeTag)
    {
      if ((string.IsNullOrEmpty(fieldTypeTag)) || (string.IsNullOrEmpty(layoutFieldTypeTag))) {
        return false;
      }
      return fieldTypeTag == layoutFieldTypeTag;
    }

    /// <summary>
    /// Helper method that returns an array of strings corresponding to 
    /// each of the categories associated with all saved layouts for the 
    /// specified field type.
    /// </summary>
    /// <param name="fieldTypeTag">The field type tag for which to 
    /// consider layouts.</param>
    /// <returns>An array of strings with the category names - suitable 
    /// for display to the user.</returns>
    private string[] GetCurrentSavedLayoutCategories(string fieldTypeTag)
    {
      List<string> result = new List<string>();
      foreach (SavedLayout savedLayout in savedLayouts) {
        if ((MatchesFieldTypeTag(fieldTypeTag, savedLayout.FieldTypeTag)) &&
            (!string.IsNullOrEmpty(savedLayout.Category))) {
          result.Add(savedLayout.Category);
        }
      }
      return result.ToArray();
    }

  }
}
