import pathlib

p = pathlib.Path('task.csproj')
text = p.read_text(encoding='utf-8', errors='ignore')
needle = '<Reference Include="System.Windows.Forms" />'
if needle not in text:
    raise SystemExit('needle not found')

if 'System.Windows.Forms.DataVisualization' not in text:
    text = text.replace(needle, needle + '\n    <Reference Include="System.Windows.Forms.DataVisualization" />', 1)

p.write_text(text, encoding='utf-8')
print('patched')
