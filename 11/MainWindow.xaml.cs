private void CalculateButton_Click(object sender, RoutedEventArgs e) {
    if (!int.TryParse(HoursTextBox.Text, out int hours)) {
        MessageBox.Show("Неверное значение часов");
        return;
    }
    if (!(AssistantRadio.IsChecked == true ||
          DocentRadio.IsChecked == true ||
          ProfessorRadio.IsChecked == true)) {
        MessageBox.Show("Выберите должность");
        return;
    }
    if (!(TaxYesRadio.IsChecked == true || TaxNoRadio.IsChecked == true)) {
        MessageBox.Show("Выберите налоговый режим");
        return;
    }
    decimal rate = AssistantRadio.IsChecked == true ? 150m :
        DocentRadio.IsChecked == true ? 250m : 350m;
    decimal salary = hours * rate;
    if (TaxYesRadio.IsChecked == true) {
        salary *= 0.87m; // 13% НДФЛ
    }
    ResultTextBlock.Text = $"Зарплата: {salary:F2} руб.";
}