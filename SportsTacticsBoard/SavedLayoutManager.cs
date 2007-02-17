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
// This program is distributed in the hope that it will be useful,SavedCu
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
    private List<SavedLayout> savedLayouts;

    public SavedLayoutManager() {
      savedLayouts = new List<SavedLayout>();
    }

    private static bool MatchesFieldTypeTag(string fieldTypeTag, string layoutFieldTypeTag) {
      if ((string.IsNullOrEmpty(fieldTypeTag)) || (string.IsNullOrEmpty(layoutFieldTypeTag))) {
        return false;
      }
      return fieldTypeTag == layoutFieldTypeTag;
    }

    /// <summary>
    /// Updates the specified menu by inserting menu items for each of the saved layouts 
    /// into the menu. The items are inserted into sub-menus corresponding to the categories.
    /// Only saved layouts for the specified field type will be inserted.
    /// </summary>
    /// <param name="menuToInsertInto"></param>
    /// <param name="fieldTypeTag"></param>
    /// <param name="menuItemClickEventHandler"></param>
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

    public FieldObjectLayout GetLayoutForMenuItem(ToolStripMenuItem menuItem, string fieldTypeTag) {
      string name = menuItem.Text;
      foreach (SavedLayout savedLayout in savedLayouts) {
        if ((MatchesFieldTypeTag(fieldTypeTag, savedLayout.FieldTypeTag)) &&
            (savedLayout.Name == name)) {
          return savedLayout.Layout;
        }
      }
      return null;
    }

    private string[] GetCurrentSavedLayoutCategories(string fieldTypeTag) {
      List<string> result = new List<string>();
      foreach (SavedLayout savedLayout in savedLayouts) {
        if ((MatchesFieldTypeTag(fieldTypeTag, savedLayout.FieldTypeTag)) &&
            (!string.IsNullOrEmpty(savedLayout.Category))) {
          result.Add(savedLayout.Category);
        }
      }
      return result.ToArray();
    }

    public void SaveCurrentLayout(FieldObjectLayout layoutToSave, string fieldTypeTag) {
      SavedLayout sl =
        SavedLayoutInformation.AskUserForSavedLayoutDetails(layoutToSave,
                                                            fieldTypeTag,
                                                            GetCurrentSavedLayoutCategories(fieldTypeTag));
      if (null != sl) {
        savedLayouts.Add(sl);
      }
    }

  }
}
